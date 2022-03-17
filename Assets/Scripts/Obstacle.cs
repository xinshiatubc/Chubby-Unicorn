using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject cane, caneReversed, candy, candyReversed;

    void Start()
    {
        //Assign random rotation degree to candy cane
        RandomRotate(cane);
        RandomRotate(caneReversed);
        //Assign random color to candy top
        RandomColour(candy);
        RandomColour(candyReversed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            //If the player hits the trigger collider after passing the obstacle, increase the score
            GameController.instance.PlayerScored();
        }
    }

    void RandomRotate(GameObject gameObject)
    {
        gameObject.transform.Rotate(0f, 0f, Random.Range(-20f, 20f));
    }

    void RandomColour(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0F, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
