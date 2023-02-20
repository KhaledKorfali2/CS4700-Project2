/*************************************************************** 
*file: Program1.cs 
*author: K. Korfali 
*class: CS 4700 – Game Development 
*
*assignment: Program 2 
*date last modified: 2/14/2023 
* 
*purpose: This program takes in the user's physical mouse inputs and 
*translates that to in game camera movement. This allows the
*player to look around the scene.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Controlls mouse sensitivity movement (higher = more sensitive)
    //Can be edited in inspector window for fine tune adjustments
    public float mouseSensitivity;

    //Refrence to the player body so that the program knows player's
    //in game orientation
    //Transform object can be asigned in inspector window
    public Transform playerBody;

    //Stores x and y position of mouse
    private float mouseX;
    private float mouseY;

    //Keeps track of the amount the camera has rotated around x-axis
    private float xRotation;

    //MouseLook Constructor
    MouseLook()
    {
        mouseSensitivity = 100f;
        xRotation = 0f;

        mouseX = 0f;
        mouseY = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
