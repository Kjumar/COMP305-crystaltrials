using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPlatform : MonoBehaviour
{
    public bool isColliding = false;
    public GameObject collidingObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
            collidingObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
