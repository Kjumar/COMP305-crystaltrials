
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Enums for levels
    // Lists out all the scenes we have in the game
    // The names of the enum items MUST be same as the Scene object name!!!
    public enum Level
    {
        MainMenu,
        Level1,
        Level2,
        Level3
    }

    // Singleton design pattern. Easier to access the GameManager.
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Prefab")]
    [SerializeField]
    private GameObject playerPrefab = null;

    // UI screens
    [Header("Screens")]

    [SerializeField]
    private GameObject victoryScreen = null;

    [SerializeField]
    private GameObject gameoverScreen = null;

    [SerializeField]
    private GameObject gameHudScreen = null;

    [SerializeField]
    private HealthBar healthBar = null;

    [SerializeField]
    private Text scoreText = null;

    private Level currentLevel = Level.MainMenu;

    private int score = 0;

    private int lastScore = 0;
    private int lastHealth = 6;

    private PlayerController player = null;

    public HealthBar HealthBar
    {
        get
        {
            return healthBar;
        }
    }

    private void Awake()
    {
        // Make sure there's only one GameManager
        if(GameManager.Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance for Singleton design pattern
        instance = this;

        // Tell Unity DO NOT destory this game Object when changing scene
        DontDestroyOnLoad(this.gameObject);
      }

    private void OnLevelWasLoaded(int level)
    {
        if(currentLevel > Level.MainMenu)
        {
            lastScore = score;
            scoreText.text = this.score.ToString();
            healthBar.setHealth(lastHealth);

            GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if(spawnPoint != null)
            {
                GameObject player = Instantiate(playerPrefab);
                player.transform.position = spawnPoint.transform.position;
                this.player = player.GetComponent<PlayerController>();

                CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
                cam.Follow = player.transform;
            }
        }
        else
        {
            score = 0;
            lastScore = 0;
            //healthBar.setHealth(6);
        }
    }

    public void LoadLevel(Level scene)
    {
        if (scene > Level.Level3)
        {
            ShowVictory();
        }
        else
        {
            currentLevel = scene;

            Time.timeScale = 1f; // reset this before loading a scene, scene we mess with this value in the pause menu
            SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);

            // Toggle GameHUD
            gameHudScreen.SetActive(currentLevel > Level.MainMenu);
            victoryScreen.SetActive(false);
            gameoverScreen.SetActive(false);
        }
    }

    public void LoadNextLevel()
    {
        lastHealth = healthBar.GetHealth();
        // Loads the next level by incrementing the index
        if (currentLevel < Level.Level3)
            LoadLevel(currentLevel + 1);
    }

    public void ReloadLevel()
    {
        score = lastScore;
        LoadLevel(currentLevel);
    }

    public void LoadMainMenu()
    {
        score = 0;
        lastHealth = 6;
        LoadLevel(Level.MainMenu);
    }

    // UI

    public void ShowVictory()
    {
        victoryScreen.SetActive(true);
        player.enabled = false;
    }

    public void ShowGameOver()
    {
        gameoverScreen.SetActive(true);
    }

    public void AddScore(int s)
    {
        this.score += s;
        scoreText.text = this.score.ToString();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
