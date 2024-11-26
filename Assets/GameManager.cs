using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI tmp;
    public List<Image> hearts;
    private int lives = 3;

    void Start()
    {
        
        GameEvents.current.onObstacleTriggerEnter += OnObstacleCollision;
    }


    void Update()
    {
        tmp.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            score += 1;
            if(score % 5 == 0)
            {
                Debug.Log("Speed Change");
                GameEvents.current.SpeedChange();
            }
        }
    }

    private void OnObstacleCollision()
    {
        if(lives <= 1)
        {
            GameOver();
        }
        LoseLife();

    }

    private void LoseLife()
    {
        lives--;
        hearts[lives].enabled = false;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        NextScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseProgram()
    {
        Application.Quit();
    }

    public int GetScore()
    {
        return score;
    }
}
