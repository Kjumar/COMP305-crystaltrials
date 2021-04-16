using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Go to the next scene
            GameManager.Instance.LoadNextLevel();
        }
    }
}
