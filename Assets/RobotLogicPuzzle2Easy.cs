using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotLogicPuzzle2Easy : MonoBehaviour
{
    public ClickButton[] mybuttons;
    public List<int> colourList;
   // [SerializeField] private Animator doorAnim;
  //  [SerializeField] private string openAnimationName = "DoorOpen";
    public float showtime = 0.5f;
    public float pausetime = 0.5f;
    public int endOf = 3;
    public int Level = 0;
    public int playerLevel = 0;
    public bool robot = false;
    public bool player = false;
    public GameObject trigger;
    private int myRandom;
    public GameObject door;
    //public Button StartButton;
    //public Text gameOver;
    public Text scoreText;
    [SerializeField] private int score;
    
    private void Start()
    {
        for (int i = 0; i < mybuttons.Length; i++)
        {
            mybuttons[i].onClick += ButtonClicked;
            mybuttons[i].myNumber = i;
        }
        //doorAnim = gameObject.GetComponent<Animator>(); 
        //for some reason when this is called the door would not open regardless of what happend previously
        // - really should have taken a video of that 
    }
    
   
    private void ButtonClicked(int _number)
    {
       
        if (player)
        {
            if (_number == colourList[playerLevel])
            {
                playerLevel += 1;
                score += 1;
                scoreText.text = score.ToString();
            }
            else
            {
                GameOver();
            }

            if (playerLevel == Level)
            {
                Level += 1;
                playerLevel = 0;
                player = false;
                robot = true;
            }
        }

        // if(score <= endOf) this would cause the game to immediately end after one press of the puzzle. 
        if (score == endOf)
        {
            Debug.Log("GameOver");
           // StartButton.interactable = true;
            robot = false;
            player = false;
            //doorAnim.Play(openAnimationName, 0, 0.0f);
            door.SetActive(false); 
        }
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit button;
            if (Physics.Raycast(ray, out button))
            {
                for (int i = 0; i < mybuttons.Length; i++)
                {
                    if (button.collider.gameObject == mybuttons[i].gameObject)
                    {
                        ButtonClicked(i);
                    }
                }

            }
        }
            if (robot)
        {
            robot = false;
            StartCoroutine(Robot());
        }


    }
    private IEnumerator Robot()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Level; i++)
        {
            if (colourList.Count < Level)
            {
                myRandom = Random.Range(0, mybuttons.Length);
                colourList.Add(myRandom);
            }
            mybuttons[colourList[i]].ClickedColour();
            yield return new WaitForSeconds(showtime);
            mybuttons[colourList[i]].UnClickedColour();
            yield return new WaitForSeconds(pausetime);
        }
        player = true;
    }

    public void StartGame()
    {
        robot = true;
        score = 0;
        playerLevel = 0;
        Level = 2;
        //gameOver.text = "";
       // scoreText.text = score.ToString();
       //StartButton.interactable = false;

    }
    private void GameOver()
    {
       // gameOver.text = "Game Over";
        //StartButton.interactable = true;
        player = false;
    }
}
