using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            //If the player hits the trigger collider after passing the obstacle, increase the score
            GameController.instance.PlayerScored();
        }
    }
}
