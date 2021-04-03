/* PauseMenuController.cs
 * ------------------------------
 * Author(s):
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last Edited: 2021-04-03
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
}
