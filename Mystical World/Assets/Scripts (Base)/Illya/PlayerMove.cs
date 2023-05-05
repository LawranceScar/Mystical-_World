using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;

    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;

    private bool isCanJump;

    Vector3 moveDirection;
    Vector3 jumpDirection;
    Rigidbody rb;

    public Transform Camera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();

    }
    private void Update()
    {
        MyInput();
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                 Camera.localEulerAngles.y,
                                                 transform.localEulerAngles.z);
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxis("Jump");
    }
    private void MovePlayer()
    {
        moveDirection = new Vector3(moveForce * horizontalInput, 0, moveForce * verticalInput);
        rb.AddRelativeForce(moveDirection, ForceMode.Force);

    }
    private void JumpPlayer()
    {
        jumpDirection = transform.up * jumpInput;
        if (isCanJump)
        {
            rb.AddRelativeForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isCanJump = false;
        }
    }
}
