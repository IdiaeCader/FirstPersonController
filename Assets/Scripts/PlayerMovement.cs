using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Camera playerCamera;
    public float defaultFOV = 90f;
    public float sprintingFOV = 100f;
    public float t = 0.1f;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public bool isClimbing;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            hasJumped = false;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded && !hasJumped)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            hasJumped = true;
        }

        if (isClimbing && !isGrounded)
        {
            velocity.y = 1;
            hasJumped = true;
        }
        if (!isClimbing && !isGrounded)
        {
            isClimbing = false;
            isGrounded = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCamera.fieldOfView = sprintingFOV;
            speed = speed * 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 1.5f;
            playerCamera.fieldOfView = defaultFOV;
        }
    }
}
