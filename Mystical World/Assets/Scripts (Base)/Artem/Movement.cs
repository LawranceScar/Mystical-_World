using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController Controller;

    [SerializeField] private Transform CameraTransform;


    [SerializeField] private float Force = 60;
    private float StartForce = 0;
    private float SprintForce = 0;
    [SerializeField] private float JumpForce = 100;

    private float MoveHorizontal;
    private float MoveVertical;
    private float Jump;
    private float Sprint;

    private float JumpCount = 0;
    private float MaxJumpCount = 2;

    private bool Dash;
    [SerializeField] private float DashDistance = 2;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        StartForce = Force;
        SprintForce = Force * 2;
    }

    void Update()
    {
        
        All_Inputs();
        Debug.Log($"Horizontal = {MoveHorizontal}");
        Debug.Log($"MoveVertical = {MoveVertical}");
        Debug.Log($"Jump = {Jump}");
        Debug.Log($"Dash = {Dash}");

        if (Sprint != 0.0f && MoveVertical > 0.0f)
        {
            Force = SprintForce;
        }
        else
        {
            Force = StartForce;
        }
        

        Vector3 HorizontalPower = MoveHorizontal * gameObject.transform.right;
        Vector3 VerticalPower = MoveVertical * gameObject.transform.forward;
        Vector3 JumpPower = Jump * gameObject.transform.up;
        Vector3 DashPower = Vector3.zero;

        /*       Vector3 LookForward = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
           Quaternion PlayerForward = Quaternion.LookRotation(LookForward);
        Quaternion Rotation = PlayerForward * CameraTransform.rotation;
        float yVelocity = 0.0f;
        float smooth = 0.1f;
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Rotation.eulerAngles.y, ref yVelocity, smooth);
        transform.rotation = Quaternion.Euler(0, yAngle, 0); */
        //transform.LookAt(Horizontal, Vertical);

        if (Dash)
            DashPower =  Dashing(HorizontalPower + VerticalPower);

        Controller.Move((HorizontalPower + Physics.gravity) * Force * Time.deltaTime);
        Controller.Move((VerticalPower + Physics.gravity) * Force * Time.deltaTime);
        
        if (JumpCount <= MaxJumpCount)
        {
            Controller.Move((JumpPower + Physics.gravity) * JumpForce * Time.deltaTime);

            JumpCount = JumpCount + 1;
        }
        Controller.Move(DashPower);

       // RaycastHit Target;

        //if (Physics.Raycast(gameObject.transform.position, PlayerVerticalPower + PlayerHorizontalPower, 1.0f, Target))
    }

    void All_Inputs()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");
        Jump = Input.GetAxis("Jump");
        Sprint = Input.GetAxis("Sprint");
        Dash = Input.GetKeyUp(KeyCode.X);
    }

    Vector3 Dashing( Vector3 Direction)
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
            JumpCount = 0.0f;
        }
    }
}

