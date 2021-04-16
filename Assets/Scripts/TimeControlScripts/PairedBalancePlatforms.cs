using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairedBalancePlatforms : MonoBehaviour, TimeShiftable
{
    [Header("Platform 1")]
    [SerializeField] private DetectorPlatform plat1;
    [SerializeField] private float p1Height = 0;
    private Rigidbody2D p1rb;

    [Header("Platform 2")]
    [SerializeField] private DetectorPlatform plat2;
    [SerializeField] private float p2Height = 0;
    private Rigidbody2D p2rb;

    private float p1Root = 0; // anchor y position
    private float p2Root = 0;
    private float speed = 5f;
    private float stopRange;

    public float timeScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        p1Root = plat1.transform.position.y;
        p2Root = plat2.transform.position.y;

        p1rb = plat1.gameObject.GetComponent<Rigidbody2D>();
        p2rb = plat2.gameObject.GetComponent<Rigidbody2D>();

        stopRange = speed / 59;
    }

    // Update is called once per frame
    void Update()
    {
        float scaledSpeed = speed * Time.deltaTime * timeScale;
        if (plat1.isColliding)
        {
            if (plat1.gameObject.transform.position.y > p1Root - (p1Height / 2))
            {
                p1rb.velocity = new Vector2(0f, -speed);
            }
            else
            {
                p1rb.velocity = new Vector2();
            }
            if (plat2.gameObject.transform.position.y < p2Root + (p2Height / 2))
            {
                p2rb.velocity = new Vector2(0f, speed);
            }
            else
            {
                p2rb.velocity = new Vector2();
            }
            PlayerController player = plat1.collidingObject.GetComponent<PlayerController>();
            player.SetVelocity(p1rb.velocity);
        }
        else if (plat2.isColliding)
        {
            if (plat2.gameObject.transform.position.y > p2Root - (p2Height / 2))
            {
                p2rb.velocity = new Vector2(0f, -speed);
            }
            else
            {
                p2rb.velocity = new Vector2();
            }
            if (plat1.gameObject.transform.position.y < p1Root + (p1Height / 2))
            {
                p1rb.velocity = new Vector2(0f, speed);
            }
            else
            {
                p1rb.velocity = new Vector2();
            }
            PlayerController player = plat2.collidingObject.GetComponent<PlayerController>();
            player.SetVelocity(p2rb.velocity);
        }
        else
        {
            if (p1rb.gameObject.transform.position.y < p1Root - stopRange)
            {
                p1rb.velocity = new Vector2(0f, speed);
            }
            else if (p1rb.gameObject.transform.position.y > p1Root + stopRange)
            {
                p1rb.velocity = new Vector2(0f, -speed);
            }
            else
            {
                p1rb.velocity = new Vector2();
            }

            if (p2rb.gameObject.transform.position.y < p2Root - stopRange)
            {
                p2rb.velocity = new Vector2(0f, speed);
            }
            else if (p2rb.gameObject.transform.position.y > p2Root + stopRange)
            {
                p2rb.velocity = new Vector2(0f, -speed);
            }
            else
            {
                p2rb.velocity = new Vector2();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawCube(plat1.gameObject.transform.position, new Vector3(0.2f, p1Height, 0f));
        Gizmos.DrawCube(plat2.gameObject.transform.position, new Vector3(0.2f, p2Height, 0f));
    }

    public void SetTimeScale(float scale)
    {
        timeScale = scale;
    }
}
