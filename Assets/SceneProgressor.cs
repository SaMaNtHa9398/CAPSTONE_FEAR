using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneProgressor : MonoBehaviour
{
    public int sceneNumber; 
   public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber); 
    }
  

}
