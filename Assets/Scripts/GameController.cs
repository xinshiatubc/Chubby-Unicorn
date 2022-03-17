using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject countDownUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    private int score = 0;
    public int bestScore = 0;

    public bool gameOver = false;        
    

    void Awake()
    {
        //If no game controller present, set this to be the one.
        if (instance == null)
            instance = this;
        //Destroy duplicate
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        //If it's a first time user, create a data file
        if (!File.Exists(Application.persistentDataPath + "/data.txt"))
        {
            SaveSystem.SaveData(this);
        }
        //Load the history best score
        else
        {
            GameData data = SaveSystem.LoadData();
            bestScore = data.bestScore;
        }
        
        //Delayed start
        StartCoroutine("StartCountdown");
    }
    void Update()
    {
        //If the game is over and the player has press the keyboard to restart, reload the current scene.
        if (gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void PlayerScored()
    {
        //If the game is over, the player can't score.
        if (gameOver)
            return;
        //increase the score
        score++;
        FindObjectOfType<AudioManager>().PlayAudio("Score");
        scoreText.text = "Score: " + score.ToString();
        
        //Save the best score to local file
        if(score > bestScore)
        {
            bestScore = score;
            SaveSystem.SaveData(this);
        }
    }


    public void PlayerDied()
    {
        //Set the game to be over.
        gameOver = true;
        FindObjectOfType<AudioManager>().PlayAudio("GameOver");

        //Update Game Over GUI
        bestScoreText.text = "Best: " + bestScore.ToString();
        gameOverUI.SetActive(true);
    }


    IEnumerator StartCountdown()
    {
        //Freeze the game
        Time.timeScale = 0;
        //Delay the game start for 3.5 second to wait for the countdown animation complete
        float pauseTime = Time.realtimeSinceStartup + 3.5f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDownUI.gameObject.SetActive(false);
        //Restart the game
        Time.timeScale = 1;

    }
}
