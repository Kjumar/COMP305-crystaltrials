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
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
