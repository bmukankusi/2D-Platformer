using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public int lifeScoreCount = 3; 
    public GameObject optionsPanel; 
    public Button replayButton;
    public Button quitButton;

    void Start()
    {
        optionsPanel.SetActive(false); 

        // Assign button functions
        replayButton.onClick.AddListener(ReplayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void Update()
    {
        if (lifeScoreCount <= 0)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        optionsPanel.SetActive(true); // Show the Game Over panel
        Time.timeScale = 0f; 
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit game (works in a built application)
        Debug.Log("Game Quit!"); // Useful for testing in Unity Editor
    }
}
