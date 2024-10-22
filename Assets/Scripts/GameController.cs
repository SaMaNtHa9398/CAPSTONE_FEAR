using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    public GameObject enabledPuzzle; 

    private void Awake()
    {
        //puzzles = Resources.LoadAll<Sprite>)("Sprites"); 
    }

    private void Start()
    {
        GetButtons();
        AddListeners();
        //AddGamePuzzle();
        shuffle(gamePuzzles);
        AddGamePuzzles();
        shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2; 
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton"); 
        for(int i =0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if(index == looper /2)
            {
                index = 0; 

            }
            gamePuzzles.Add(puzzles[index]);
            index++; 
        }
    }    

    void AddListeners()
    {
        foreach (Button btns in btns)
        {
           // btns.onClick.AddListener(() => PickAPuzzle());
        }
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("game finished");
            Debug.Log("it took you " + countGuesses + " guess(es) t0 finish the game");
            enabledPuzzle.SetActive(false);
        }
    }

    void shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp; 
        }
    }
       
}
