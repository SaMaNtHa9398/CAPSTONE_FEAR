using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // code from user1production with improvements 
    public GameObject flashLight;

    public AudioSource turnOnSound;
    public AudioSource turnOffSound;

    private bool isFlashlightOn = false;
    // Start is called before the first frame update
    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        flashLight.SetActive(isFlashlightOn);

        if (isFlashlightOn)
        {
            // Play the "turn on" sound
           // turnOnSound.Play();
        }
        else
        {
            // Play the "turn off" sound
           // turnOffSound.Play();
        }

    }
}
