using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;
    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;

    private int maxJumpCount = 2;
    private int jumpCount = 0;

    Vector3 moveDirection;
    Vector3 jumpDirection;
    Rigidbody rb;

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
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxis("Jump");
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddRelativeForce(moveDirection.normalized * moveForce, ForceMode.Force);
    }
    private void JumpPlayer()
    {
        jumpDirection = orientation.up * jumpInput;
        if(jumpCount <= maxJumpCount  && jumpInput > 0)
        {
            rb.AddRelativeForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse); 
            jumpCount++;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
