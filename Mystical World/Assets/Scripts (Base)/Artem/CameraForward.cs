using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraForward : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        gameObject.transform.forward = Camera.transform.forward;
    }
}