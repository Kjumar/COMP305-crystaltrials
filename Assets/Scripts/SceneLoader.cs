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
    public void LoadLevel1()
    {
        Time.timeScale = 1f; // reset this before loading a scene, scene we mess with this value in the pause menu
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
