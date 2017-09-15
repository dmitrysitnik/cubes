using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    const int HEALTH_MAX = 3;
    public static bool gameOver = false;
    public  bool restart = false;
    public static int score = 0;
    public static float gameTime = 0;
    public static int playerHealth = HEALTH_MAX;

    public Text gameOverText;
    public Text restartText;
    public Text scoreText;
    public Text playedTime;

    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        playedTime.text = "";
        scoreText.text = "0";
        playerHealth = HEALTH_MAX;

    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
        if (gameOver)
        {
            gameOverText.text = "GAME OVER\nPlayedTime";
            restartText.text = "Press 'R' to restart";
            playedTime.text = gameTime.ToString() + " Seconds";
            restart = true; //Allow restart
        }
        if (restart)
        {
            //Restart();
        }
    }

    public static void GameOver()
    {
        gameOver = true;
        gameTime = Time.fixedTime;
    }

    public void Restart()
    {     
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
    }

    public static void AddPoints()
    {
        score += 10;
    }

}
