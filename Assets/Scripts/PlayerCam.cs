using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{/*
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 90f);

        // rotate cam 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }*/

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f; 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 
    }
}
