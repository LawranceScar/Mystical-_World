using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController Controller;

    [SerializeField] private Transform CameraTransform;


    [SerializeField] private float Speed = 60;
    private float StartSpeed = 0;
    private float SprintSpeed = 0;
    [SerializeField] private float JumpSpeed = 100;

    private float MoveHorizontal;
    private float MoveVertical;
    private float Jump;
    private float Sprint;

    private int JumpCount = 0;
    private int MaxJumpCount = 2;

    private bool Dash;
    [SerializeField] private float DashDistance = 2;

    public bool CanMove = true;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        StartSpeed = Speed;
        SprintSpeed = Speed * 2;
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Move()
    {
        All_Inputs();

        if (Sprint != 0.0f && MoveVertical > 0.0f)
        {
            Speed = SprintSpeed;
        }
        else
        {
            Speed = StartSpeed;
        }


        Vector3 HorizontalPower = MoveHorizontal * CameraTransform.transform.right;
        Vector3 VerticalPower = MoveVertical * CameraTransform.transform.forward;
        Vector3 JumpPower = Jump * gameObject.transform.up;
        Vector3 DashPower = Vector3.zero;

        Vector3 LookForward = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        Quaternion PlayerForward = Quaternion.LookRotation(LookForward);
        Quaternion Rotation = PlayerForward * CameraTransform.rotation;
        float yVelocity = 0.0f;
        float smooth = 0.1f;
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Rotation.eulerAngles.y, ref yVelocity, smooth);
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
        //transform.LookAt(HorizontalPower + VerticalPower);

        if (Dash)
            DashPower = Dashing(HorizontalPower + VerticalPower);

        Controller.Move((HorizontalPower + Physics.gravity) * Speed * Time.deltaTime);
        Controller.Move((VerticalPower + Physics.gravity) * Speed * Time.deltaTime);

        if (JumpCount <= MaxJumpCount && Jump > 0.0f)
        {
            Controller.Move((JumpPower + Physics.gravity) * JumpSpeed * Time.deltaTime);

            JumpCount++;
        }
        Controller.Move(DashPower);

        gameObject.transform.localEulerAngles = new Vector3(0.0f, gameObject.transform.localEulerAngles.y, 0.0f);
    }

    private void All_Inputs()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");
        Jump = Input.GetAxis("Jump");
        Sprint = Input.GetKeyDown(KeyCode.Space) ? 1.0f : 0.0f;
        Dash = Input.GetKeyUp(KeyCode.X);
    }

    private Vector3 Dashing(Vector3 Direction)
    {
        Direction = Direction.normalized;
        Vector3 DashTarget;
        RaycastHit Hit;

        if (Direction == new Vector3(0.0f, 0.0f, 0.0f))
            DashTarget = gameObject.transform.position - gameObject.transform.forward * DashDistance;
        else
            DashTarget = gameObject.transform.position + Direction * DashDistance;

        if (Physics.Raycast(gameObject.transform.position, Direction, out Hit, DashDistance))
        {
            DashTarget = Hit.point;
        }

        return DashTarget - gameObject.transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
        }
    }

    public void MoveTowards(Vector3 TargetPosition, float Speed)
    {
        Vector3 Direction = (TargetPosition - gameObject.transform.position).normalized;

        Controller.Move(Direction * Speed * Time.deltaTime);
    }
}


