using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOffsetCamera : MonoBehaviour
{

    [SerializeField] public Transform Camera;

    // Update is called once per frame
    void Update()
    {
        if (Camera != null)
        {
            transform.LookAt(Camera);
        }
        else
        {
            Debug.LogError("No Camera Attached");
        }
    }
}
