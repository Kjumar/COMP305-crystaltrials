using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShiftController : MonoBehaviour
{
    // this object stores and maintains a speed multiplyer that other scripts can reference

    private float speed = 1f; // how fast time should be moving (i.e. speed = 1 means time is moving at 1x speed)

    private float timeRemaining = 0f; // the duration of the curent time control effect

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                RestoreTime();
            }
        }
    }

    public void SlowTime(float timeScale, float duration)
    {
        speed = timeScale;
        timeRemaining = duration;
    }

    public void RestoreTime()
    {
        timeRemaining = 0;
        speed = 1;
    }

    public float GetTimeScale()
    {
        return speed;
    }
}
