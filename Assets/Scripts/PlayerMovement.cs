using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Camera playerCamera;
    public float defaultFOV = 90f;
    public float sprintingFOV = 100f;
    public float fovSmoothSpeed = 8f;

    public float walkSpeed = 8f;
    public float sprintMultiplier = 1.5f;
    private float currentSpeed;

    public float gravity = -30;
    public float jumpHeight = 3f;

    public bool isClimbing;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool hasJumped;

    void Start()
    {
        currentSpeed = walkSpeed;
        playerCamera.fieldOfView = defaultFOV;
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            hasJumped = false;
        }

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButton("Jump") && isGrounded && !hasJumped)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            hasJumped = true;
        }

        if (isClimbing && !isGrounded && Input.GetButton("Jump"))
        {
            velocity.y = 3f;
            hasJumped = true;
        }

        if (!isClimbing && !isGrounded)
        {
            isClimbing = false;
            isGrounded = true;
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Sprint + Smooth FOV

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Speed handling (safe, no stacking)
        currentSpeed = isSprinting ? walkSpeed * sprintMultiplier : walkSpeed;

        // Target FOV
        float targetFOV = isSprinting ? sprintingFOV : defaultFOV;

        // Smooth FOV transition
        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            targetFOV,
            Time.deltaTime * fovSmoothSpeed
        );

    }
}
