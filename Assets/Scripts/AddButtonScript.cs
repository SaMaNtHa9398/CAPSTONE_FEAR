using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonScript : MonoBehaviour
{
    [SerializeField]
    private Transform puzzlefield;
    [SerializeField]
    private GameObject btn;
    public int numberPuzzles;

    private void Awake()
    {
        for (int i = 0; i < numberPuzzles; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzlefield, false); 
        }    
    }
}
