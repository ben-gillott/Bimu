using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Object References")]
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    [Space]
    [Header("Variables")]
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float gravity = -18.81f;
    public float jumpHeight = 2f;
    private Vector3 velocity;
    private bool isGrounded;



    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //Get floor movement
        float x = Input.GetAxis("Horizontal");
        //Apply the movement
        Vector3 move = transform.right * x;
        controller.Move(move * speed * Time.deltaTime);


        //Get jump input
        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Apply the gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
