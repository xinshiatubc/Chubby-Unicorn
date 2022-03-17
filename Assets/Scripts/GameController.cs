using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;            

    private int score = 0;                        
    public bool gameOver = false;                

    void Awake()
    {
        //If no game controller present, set this to be the one.
        if (instance == null)
            //set this one to be it
            instance = this;
        //Destroy duplicate
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        //If the game is over and the player has pressed some input, reload the current scene.
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
    }


    public void PlayerDied()
    {
        //Set the game to be over.
        gameOver = true;
    }
}