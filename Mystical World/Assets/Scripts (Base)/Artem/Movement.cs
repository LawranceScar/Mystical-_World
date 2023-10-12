using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController Controller;

    [SerializeField] private Transform Camera;


    [SerializeField] private float Force = 60;
    private float StartForce = 0;
    private float SprintForce = 0;
    [SerializeField] private float JumpForce = 100;

    private float MoveHorizontal;
    private float MoveVertical;
    private float Jump;
    private float Sprint;

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

        if (Sprint != 0.0f && MoveVertical > 0.0f)
        {
            Force = SprintForce;
        }
        else
        {
            Force = StartForce;
        }

        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, Camera.localEulerAngles.y, this.transform.localEulerAngles.z);

        Vector3 HorizontalPower = MoveHorizontal * this.transform.right;
        Vector3 VerticalPower = MoveVertical * this.transform.forward;
        Vector3 JumpPower = Jump * this.transform.up;
        Vector3 DashPower = Vector3.zero;
        
        if (Dash)
          DashPower =  Dashing(HorizontalPower + VerticalPower);

        Controller.Move((HorizontalPower + Physics.gravity) * Force * Time.deltaTime);
        Controller.Move((VerticalPower + Physics.gravity) * Force * Time.deltaTime);
        Controller.Move((JumpPower + Physics.gravity) * JumpForce * Time.deltaTime);
        Controller.Move(DashPower);
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

        if (Physics.SphereCast(gameObject.transform.position, 1.5f, Direction, out Hit, DashDistance))
        {
             DashTarget = Hit.point;
        }
        
        return DashTarget - gameObject.transform.position;
    }
}

