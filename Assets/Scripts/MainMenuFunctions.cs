/* MainMenuFunctions.cs
 * ------------------------------
 * This class holds public functions for use in the main menu, when the user selects an option
 * 
 * Author(s):
 *      - Jay Ganguli
 *      - 
 *      - 
 * 
 * Last Edited: 2021-02-17
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public Canvas optionMenu;

    public void NewGame()
    {
        GameManager.Instance.LoadLevel(GameManager.Level.Level1);
    }

    public void Exit()
    {
        GameManager.Instance.Exit();
    }
}
