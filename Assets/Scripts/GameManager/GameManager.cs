using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public int playerLives = 3;
    public GameObject endSceneUI;
    public GameObject startGameUI;
    public Button replayButton;
    public Button quitButton;
    public Button startButton;

    private Vector3 lastSafePosition;

    void Start()
    {
        lastSafePosition = player.position;
        endSceneUI.SetActive(false);
        startGameUI.SetActive(true);

        replayButton.onClick.AddListener(ReplayGame);
        quitButton.onClick.AddListener(QuitGame);
        startButton.onClick.AddListener(StartGame);
    }

    void Update()
    {
        if (player.position.y < -5)
        {
            HandlePlayerRespawn(player.position);
        }
    }

    public void HandlePlayerRespawn(Vector3 waterPosition)
    {
        playerLives--;

        if (playerLives > 0)
        {
            player.position = waterPosition + new Vector3(2f, 5f, 0);
        }
        else
        {
            ShowEndScene();
        }
    }

    void ShowEndScene()
    {
        endSceneUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        startGameUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
