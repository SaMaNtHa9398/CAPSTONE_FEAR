using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDoor : MonoBehaviour
{
    InteractableCounter Pedastal;
    SlidingPuzzle Teddy;
    public DescructibleWall wall;
    public int requiredtables;
    public int completetables;
    public List<GameObject> gameObjs = new List<GameObject>();
    private HashSet<GameObject> countedObjects = new HashSet<GameObject>();
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in gameObjs)
        {
            // Ensure the object has the required component
            var pedestal = obj.GetComponent<InteractableCounter>();
            //if (pedestal != null && pedestal.ConditionMeet && !countedObjects.Contains(obj))
            {
                countedObjects.Add(obj); // Add to counted set
                completetables++;       // Increment completed count
            }
        }

        // Check if all required tables are completed
        if (completetables >= requiredtables)
        {
            wall.Open(); // Open the wall if the condition is met
        }
    }
}


