/* MagicDustController.cs
 * -------------------------------
 * Authors:
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last edited: 2021-04-15
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDustController : MonoBehaviour
{
    public float life = 1f;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        if (velocity == null)
        {
            velocity = new Vector3();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (velocity * Time.deltaTime);

        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
