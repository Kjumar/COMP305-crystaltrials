/* SceneLoader.cs
 * ------------------------------
 * Author(s):
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last Edited: 2021-03-19
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint = null; 

    private void OnLevelWasLoaded(int level)
    {
        GameObject prefab = Resources.Load("Prefab/Player") as GameObject;
        GameObject player = Instantiate(prefab, spawnPoint);
    }
}
