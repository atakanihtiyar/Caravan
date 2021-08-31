using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Transform mainCamera;
    private Animator animator;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;

    public float gravity = -9.81f;
    public float jumpheight = 1f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        Walk();
        Jump();
        Falling();
    }

    private void Walk()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 targetDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (targetDirection.magnitude >= 0.1f)
        {
            float smoothedTurnAngle = GetSmoothedTurnAngle(targetDirection);

            transform.rotation = Quaternion.Euler(0f, smoothedTurnAngle, 0f);

            Vector3 moveTarget = Quaternion.Euler(0f, smoothedTurnAngle, 0f) * Vector3.forward;
            controller.Move(moveTarget.normalized * speed * Time.deltaTime);

            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    private float GetSmoothedTurnAngle(Vector3 targetDirection)
    {
        float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
        float targetAngleByCamera = targetAngle + mainCamera.eulerAngles.y;
        float smoothedTurnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleByCamera, ref turnSmoothVelocity, turnSmoothTime);
        return smoothedTurnAngle;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
    }

    private void Falling()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
