using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController controller;
    Transform mainCamera;
    public Animator animator;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float gravity = -9.81f;
    public float jumpheight = 1f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 target = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (target.magnitude >= 0.1f)
        {
            // rotation
            float targetAngle = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg;
            float targetAngleByCamera = targetAngle + mainCamera.eulerAngles.y;
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleByCamera, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);

            // horizontal movement
            Vector3 moveTarget = Quaternion.Euler(0f, targetAngleByCamera, 0f) * Vector3.forward;
            controller.Move(moveTarget.normalized * speed * Time.deltaTime);

            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        // jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        // gravity
        velocity.y += gravity * Time.deltaTime;

        // vertical movement
        controller.Move(velocity * Time.deltaTime);
    }
}
