using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LockControl : MonoBehaviour
{
    public int[] result, correctCombo;
    public Renderer doorRend;
    public Collider doorCollier;

   public GameObject door; 
    private void Start()
    {
        //door.SetActive(true); 
        result = new int[] { 1, 1, 1, 1, 1 };
        correctCombo = new int[] { 1, 2, 4, 5, 3 };
        RotateWheel.Rotated += CheckResults;
    }

    private void CheckResults(string WheelName, int number)
    {
        switch (WheelName)
        {
            case "Wheel1":
                result[0] = number;
                break;
            case "Wheel2":
                result[1] = number;
                break;
            case "Wheel3":
                result[2] = number;
                break;
            case "Wheel4":
                result[3] = number;
                break;
            case "Wheel5":
                result[4] = number;
                break;
        }
        if(result[0] == correctCombo[0]&& result[1] == correctCombo[1] && result[2] == correctCombo[2] && result[3] == correctCombo[3] && result[4] == correctCombo[4] )
        {
            Debug.Log("Opened!");
            doorCollier.enabled = false;
            //door.SetActive(false); 
            doorRend.enabled = false;
        }
    }

  //private void OnDestroy()
    
      //RotateWheel.Rotated -= CheckResults;
    
}
