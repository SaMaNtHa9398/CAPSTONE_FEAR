using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        eyeFollow(); 
        
    }

    void eyeFollow()
    {
        Vector3 playerPos = player.transform.position;

        Vector3 direction = new Vector3(
           playerPos.x - transform.position.x, playerPos.y - transform.position.y, transform.position.z);

        transform.up = direction; 
    }
}
