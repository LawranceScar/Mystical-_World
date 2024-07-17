using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowing : MonoBehaviour
{
    private float DelayTime = 10.0f;
    private float NextTime = 30.0f;
    private float WaitTime = 0.0f;

    private void Start()
    {
        DelayTime = 10.0f;
        NextTime = 30.0f;
        WaitTime = 0.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Time.time > WaitTime && Time.timeScale > 0.5f)
        {
            Time.timeScale = 0.1f;
            WaitTime = Time.time + DelayTime;
        }
        else if (Time.time > WaitTime && Time.timeScale < 1.0f)
        {
            Time.timeScale = 1.0f;
            WaitTime = Time.time + NextTime;
        }
    }
}
