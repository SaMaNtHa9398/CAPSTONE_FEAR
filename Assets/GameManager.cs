using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCENE, LoadSceneMode.Additive); 
    }

    public void LoadGame()
    {
        //LoadSceneMode
        SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCENE);
        SceneManager.LoadSceneAsync((int)SceneIndexes.OPENING_CINEMATIC, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)SceneIndexes.TUTORIAL_LEVEL, LoadSceneMode.Additive); 
    }
}
