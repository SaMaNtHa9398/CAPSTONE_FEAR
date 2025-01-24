using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescructibleWall : MonoBehaviour
{
    [SerializeField] private Transform WallBroken; 
    // Start is called before the first frame update

    public void Open()
    {
        Instantiate(WallBroken, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
