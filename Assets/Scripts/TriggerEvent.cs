using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public string Tag;
    public int numberofPlayerInteract = 0;
    public float MaxTime, MaxBreakTime, TimeAppears;

    public float waitingBetweenInteractions;
    public List<GameObject> gameobjs = new List<GameObject>();
    public GameObject haunt;
    public GameObject triggerbox;
    public Animation anim;

    private void Start()
    {
        triggerbox.SetActive(true); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            numberofPlayerInteract += 1; 
        }
    }
    private IEnumerator TimeActive()
    {
        yield return new WaitForSeconds(10f); 

      
    }

}


