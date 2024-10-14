using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableCounter : MonoBehaviour
{
    public string Tag;
    public int interactionsNum = 0;
    public int requiredInteractions = 4;
    public List<GameObject> gameObjs = new List<GameObject>();
    public GameObject PuzzleImage;
    public TextMeshPro Text;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);


        if (other.gameObject.CompareTag(Tag))
        {
            GameObject[] gameObjsArray = gameObjs.ToArray();

            interactionsNum += 1;
            Text.text = interactionsNum.ToString();

        }




        if (interactionsNum == requiredInteractions)
        {
            //Debug.Log("Required interactions reached. Activating puzzle image.");
            PuzzleImage.SetActive(true);
            Text.text = requiredInteractions.ToString();
        }
       
    }
}
