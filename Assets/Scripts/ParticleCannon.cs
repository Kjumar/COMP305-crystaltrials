/* ParticleCannon.cs
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

public class ParticleCannon : MonoBehaviour
{
    [Header("Spawn Settings")]
    public float frequency = 1f;
    public Vector2 area = new Vector2();
    public Vector3 initialVelocity = new Vector3();
    public Vector3 variance = new Vector3();

    [Header("Particle Settings")]
    public GameObject particlePrefab;
    public float life = 1f;
    
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frequency)
        {
            timer = 0;

            Vector3 position = new Vector3(transform.position.x + Random.Range(-area.x/2, area.x/2),
                transform.position.y + Random.Range(-area.y/2, area.y/2),
                transform.position.z);

            GameObject newParticle = Instantiate(particlePrefab, position, Quaternion.identity, transform);

            MagicDustController dust = newParticle.GetComponent<MagicDustController>();
            if (dust)
            {
                dust.life = life;
                dust.velocity = initialVelocity + new Vector3(Random.Range(-variance.x, variance.x),
                    Random.Range(-variance.y, variance.y), 0f);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, area);
    }
}
