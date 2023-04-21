using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform Target; // ціль за якою слідкую камера

    private float Distance = 2.0f;

    private Vector3 Offset = new Vector3(0.0f, 1.0f, 0.0f);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + mouseY * 10, transform.localEulerAngles.y - mouseX * 10, 0.0f);
        transform.position = Target.position - transform.forward * Distance  + transform.right + Offset;
    }
}