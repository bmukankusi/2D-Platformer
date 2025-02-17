using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{

    private Text lifeText;
    private int lifeScoreCount;

    private bool canDamage;
    public GameManager gameManager;

    void Awake()
    {
        lifeText = GameObject.Find("LifeText")?.GetComponent<Text>();
        if (lifeText == null)
        {
            Debug.LogError("LifeText GameObject not found or does not have a Text component.");
            return;
        }

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }

        lifeScoreCount = 3;
        lifeText.text = "x" + lifeScoreCount;

        canDamage = true;
    }

    void Start()
    {
        Time.timeScale = 1f;
        gameManager.Test();
    }

    public void DealDamage(Vector3? waterPosition = null)
    {
        if (canDamage)
        {

            lifeScoreCount--;

            if (lifeScoreCount > 0)
            {
                lifeText.text = "x" + lifeScoreCount;
                gameManager.HandlePlayerRespawn(waterPosition);
            }

            if (lifeScoreCount == 0)
            {
                // RESTART THE GAME
                Time.timeScale = 0f;
                lifeText.text = "x" + lifeScoreCount;
                StartCoroutine(RestartGame());
            }


            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("GameScene-ALU");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Vector3 waterPosition = collision.transform.position;
            DealDamage(waterPosition);

        }
    }


} // class