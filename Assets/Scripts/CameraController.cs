using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] private float cameraOffsetX = 2f;
    [Range(0f, 10f)][SerializeField] private float cameraOffsetY = 2f;

    // limits on the camera positions (so we don't see past the edge of the level)
    [SerializeField] private Transform leftBound;

    private Transform player;
    
    // Update is called once per frame
    void Update()
    {
        // Make sure player is assigned to avoid null ref
        if (player == null)
            return;

        Vector3 position = transform.position;

        if (player.position.x < position.x - cameraOffsetX)
        {
            position.x = player.position.x + cameraOffsetX;
        }

        if (player.position.x > position.x + cameraOffsetX)
        {
            position.x = player.position.x - cameraOffsetX;
        }

        if (player.position.y < position.y - cameraOffsetY)
        {
            position.y = player.position.y + cameraOffsetY;
        }

        if (player.position.y > position.y + cameraOffsetY)
        {
            position.y = player.position.y - cameraOffsetY;
        }

        // clamp camera position to within bounds
        if (leftBound != null && position.x < leftBound.position.x)
        {
            position.x = leftBound.position.x;
        }

        transform.position = position;
    }

    private void OnDrawGizmos()
    {
        // Make sure leftbound is assigned to avoid null ref
        if (leftBound == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(cameraOffsetX * 2, cameraOffsetY * 2, 0.0f));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            new Vector2(leftBound.position.x, leftBound.position.y + 10f),
            new Vector2(leftBound.position.x, leftBound.position.y - 10f));
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
}
