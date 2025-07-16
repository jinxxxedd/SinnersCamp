using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void ResetGame()
    {
        lives = 3;
        SceneManager.LoadScene("StartMenuScene");
    }
}
