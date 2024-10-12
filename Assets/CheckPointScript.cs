using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    //script from https://www.youtube.com/watch?v=VtbHjGcsXLE MoreBlakeyy
    private RespawnScript respawn;
    private BoxCollider boxcollider; 

    private void Awake()
    {
        boxcollider = gameObject.GetComponent<BoxCollider>(); 
            respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
           // boxcollider.enabled = false; 
        }
    }
}
