using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShiftController : MonoBehaviour
{
    // this object manipulates TimeShiftable objects

    [SerializeField] private List<GameObject> targets;
    
    public float speed = 0.2f; // how fast time should be moving (i.e. speed = 1 means time is moving at 1x speed)

    public float duration = 3f; // the duration of the curent time control effect
    private float timer = 0f;

    private void Start()
    {

    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                RestoreTime();
            }
        }
    }

    public void SlowTime()
    {
        timer = duration;
        foreach (GameObject t in targets)
        {
            if (t.GetComponent<MovingPlatformBehavior>())
            {
                t.GetComponent<MovingPlatformBehavior>().SetTimeScale(speed);
            }
            else if (t.GetComponent<PairedBalancePlatforms>())
            {
                t.GetComponent<PairedBalancePlatforms>().SetTimeScale(speed);
            }
        }
    }

    public void RestoreTime()
    {
        foreach (GameObject t in targets)
        {
            if (t.GetComponent<MovingPlatformBehavior>())
            {
                t.GetComponent<MovingPlatformBehavior>().SetTimeScale(1f);
            }
            else if (t.GetComponent<PairedBalancePlatforms>())
            {
                t.GetComponent<PairedBalancePlatforms>().SetTimeScale(1f);
            }
        }
    }

    public void Hit()
    {
        SlowTime();
    }
}
