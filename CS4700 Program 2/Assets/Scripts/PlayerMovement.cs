/*************************************************************** 
*file: Program1.cs 
*author: K. Korfali 
*class: CS 4700 – Game Development 
*
*assignment: Program 2 
*date last modified: 2/14/2023 
* 
*purpose: This program takes in the user's physical keyboard inputs and 
*translates that to in game player movement. This allows the
*player to move around the scene.
* 
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;


    float x;
    float z;

    Vector3 move;

    PlayerMovement()
    {
        speed = 12f;

        x = 0f;
        z = 0f;

        move = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");


        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
