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

    [Header("Particle Effects")]
    public ParticleCannon cannon1;
    public ParticleCannon cannon2;

    private float p1Root = 0; // anchor y position
    private float p2Root = 0;
    private float speed = 5f;

    private float timeScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        p1Root = plat1.transform.position.y;
        p2Root = plat2.transform.position.y;

        p1rb = plat1.gameObject.GetComponent<Rigidbody2D>();
        p2rb = plat2.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float scaledSpeed = speed * Time.deltaTime * timeScale;
        if (plat1.isColliding)
        {
            plat1.transform.position = Vector2.MoveTowards(plat1.transform.position,
                new Vector2(plat1.transform.position.x, p1Root - (p1Height / 2)), speed * Time.deltaTime * timeScale);

            plat2.transform.position = Vector2.MoveTowards(plat2.transform.position,
                new Vector2(plat2.transform.position.x, p2Root + (p2Height / 2)), speed * Time.deltaTime * timeScale);

        }
        else if (plat2.isColliding)
        {
            plat2.transform.position = Vector2.MoveTowards(plat2.transform.position,
                new Vector2(plat2.transform.position.x, p2Root - (p2Height / 2)), speed * Time.deltaTime * timeScale);

            plat1.transform.position = Vector2.MoveTowards(plat1.transform.position,
                new Vector2(plat1.transform.position.x, p1Root + (p1Height / 2)), speed * Time.deltaTime * timeScale);

        }
        else
        {
            plat1.transform.position = Vector2.MoveTowards(plat1.transform.position,
                new Vector2(plat1.transform.position.x, p1Root), speed * Time.deltaTime * timeScale);

            plat2.transform.position = Vector2.MoveTowards(plat2.transform.position,
                new Vector2(plat2.transform.position.x, p2Root), speed * Time.deltaTime * timeScale);

        }

        if (timeScale == 1)
        {
            cannon2.enabled = false;
            cannon1.enabled = false;
        }
        else
        {
            cannon2.enabled = true;
            cannon1.enabled = true;
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
