using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public Transform respawnPoint;
    public GameObject player;
    public GameObject endSceneUI;
    public GameObject startSceneUI;

    void Start()
    {
        endSceneUI.SetActive(false);
        startSceneUI.SetActive(true); // Show the start UI at the beginning
        Time.timeScale = 0f; // Pause the game at the start
    }

    void Update()
    {
        // This can be used to check for other game management tasks
    }

    public void PlayerEnteredWater()
    {
        if (playerLives > 0)
        {
            playerLives--;
            RespawnPlayer();
        }
        else
        {
            ShowEndScene();
        }
    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPoint.position;
        // Reset player state if necessary
    }

    void ShowEndScene()
    {
        endSceneUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        startSceneUI.SetActive(false); // Hide the start UI
        Time.timeScale = 1f; // Resume the game
    }
}
