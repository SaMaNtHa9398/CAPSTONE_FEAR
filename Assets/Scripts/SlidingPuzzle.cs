using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
    #region Code for The Sliding Puzzle
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;
    

    private List<Transform> pieces;
    private int emptyLocation;
    public int size;
    private bool shuffling = false;
    public bool ConditionMeet = false;
    [SerializeField] private LayerMask puzzlePieceLayer;
    public DescructibleWall wall;
    AudioManager audiomanager;
    // Create the game setup with size x size pieces.
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void CreateGamePieces(float gapThickness)
    {
        // This is the width of each tile.
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                // Pieces will be in a game board going from -1 to +1.
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                                  +1 - (2 * width * row) - width,
                                                  0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                // We want an empty space in the bottom right.
                if ((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                    Debug.Log("Empty piece set at location: " + emptyLocation);
                }
                else
                {
                    // We want to map the UV coordinates appropriately, they are 0->1.
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    // UV coord order: (0, 1), (1, 1), (0, 0), (1, 0)
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
                    // Assign our new UVs to the mesh.
                    mesh.uv = uv;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<Transform>();
        CreateGamePieces(0.01f);

        // Shuffle the pieces immediately after they are created
        Shuffle();
        shuffling = true; // Ensure shuffling happens at the start
        //ConditionMeet = false;


    }
    void SetPiecesToSolvedState()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            int row = i / size;
            int col = i % size;
            pieces[i].localPosition = new Vector3(-1 + (2 * 1f / size * col) + 1f / size,
                                                   +1 - (2 * 1f / size * row) - 1f / size,
                                                   0);
        }

        // Now call CheckCompletion
        CheckCompletion();
       
    }
    // Update is called once per frame
    void Update()
    {

       
         if (!shuffling && CheckCompletion())
        {
            // Puzzle completed, trigger any actions here
            Debug.Log("Puzzle is solved!");
            //ConditionMeet = true; // Set your condition for opening the door or other actions
            wall.Open();
            audiomanager.PlaySfx(audiomanager.CorrectSound);

        }

        // If the puzzle isn't solved, handle shuffling and user interactions
        if (shuffling)
        {
            Debug.Log("Puzzle is still shuffling...");
        }
        if (CheckCompletion())
        {
           
            shuffling = false;     // Ensure the puzzle is no longer in a shuffling state
        
        }
        //if(ConditionMeet == true)
       // {
          //  wall.Open(); 
       // }


       
        // On click send out ray to see if we click a piece.
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                    {
                       
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }
        }

        SetPiecesToSolvedState();
    }

    // colCheck is used to stop horizontal moves wrapping.
    private bool SwapIfValid(int i, int offset, int colCheck)
    {
       

        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            // Swap in the game state
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);

            // Swap their positions in the world
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);

            // Update empty location
            emptyLocation = i;
            return true;
        }
        return false;
    

}

    // We name the pieces in order so we can use this to check completion.
    private bool CheckCompletion()
    {

        for (int i = 0; i < pieces.Count; i++)
        {
            // The puzzle is complete if all pieces are in the correct order
            if (pieces[i].name != $"{i}")
            {
                Debug.Log($"Piece {pieces[i].name} is not in the correct position.");
                return false;
            }
        }

        // All pieces are in place, so the puzzle is complete
        Debug.Log("Puzzle is complete!");
        return true;
    
    }

    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling = false;
       

    }

    // Brute force shuffling.
    private void Shuffle()
    {
        int count = 0;
        int last = -1;

        while (count < (size * size * size))
        {
            int rnd = Random.Range(0, size * size);
            if (rnd == last) continue;

            last = emptyLocation;

            if (SwapIfValid(rnd, -size, size)) { count++; }
            else if (SwapIfValid(rnd, +size, size)) { count++; }
            else if (SwapIfValid(rnd, -1, 0)) { count++; }
            else if (SwapIfValid(rnd, +1, size - 1)) { count++; }
        }

        Debug.Log($"Shuffling complete. Empty location: {emptyLocation}");

        // Check completion after shuffle is done
        if (CheckCompletion())
        {
            Debug.Log("Puzzle is solved after shuffle!");
        }

        // Reset the shuffling flag
        shuffling = false;
    }
    void TestSolvedState()
    {
        // Manually set pieces to the solved state
        for (int i = 0; i < pieces.Count; i++)
        {
            int row = i / size;
            int col = i % size;
            pieces[i].localPosition = new Vector3(-1 + (2 * 1f / size * col) + 1f / size,
                                                   +1 - (2 * 1f / size * row) - 1f / size,
                                                   0);
        }

        // Now check if completion is detected
        Debug.Log("Testing solved state...");
        CheckCompletion();
    }
    #endregion
}
