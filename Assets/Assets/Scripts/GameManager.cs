using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    



    [SerializeField] public int Score;
    [SerializeField] public int LifePoints = 3;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text LifeText;
    [SerializeField] private Transform BallSpawnPoint;
    [SerializeField] private Transform PaddleSpawnPoint;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject paddle;



    // Start is called before the first frame update
    void Start()
    {
        BallMovement.LifeLostEvent += LoseLife;
        RegularBrick.ScoreGainEvent += GetScore;
        Score = int.Parse(LifeText.text);
        //var newPaddle = Instantiate(paddle, PaddleSpawnPoint);
        //BallSpawnPoint = newPaddle.transform.GetChild(0).GetChild(0);
        var newBall = Instantiate(ball, BallSpawnPoint);
        
    }

    // Update is called once per frame
    void Update()
    {
        ExitGame();
        ScoreText.text = Score + "";
        LifeText.text = LifePoints + "";
        
        Lose();
        Win();
    }

    public void Lose()
    {
        if (LifePoints == 0)
            SceneManager.LoadScene(0);
    }

    public void Win()
    {
        if (Score == 1200)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ExitGame()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoseLife()
    {
        LifePoints--;
        Instantiate(ball, BallSpawnPoint);
    }

    public void GetScore()
    {
        Score += 50;
    }
}
