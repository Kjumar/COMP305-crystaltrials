/* MovingPlatformBehavior.cs
 * ------------------------------
 * Author(s):
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last Edited: 2021-04-15
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour, TimeShiftable
{
    [Header("Pathing")]
    public List<Transform> waypoints;
    public float speed = 4f;

    [Header("Particle Effects")]
    public ParticleCannon cannon;

    private int pathIndex = 0;
    private float timeScale = 1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[pathIndex].position,
                Time.deltaTime * speed * timeScale);

            if (Vector2.Distance(transform.position, waypoints[pathIndex].position) < 0.01f)
            {
                pathIndex = (pathIndex + 1) % waypoints.Count;
            }
        }

        if (timeScale == 1)
        {
            cannon.enabled = false;
        }
        else
        {
            cannon.enabled = true;
        }
    }

    public void SetTimeScale(float scale)
    {
        timeScale = scale;
    }
}
