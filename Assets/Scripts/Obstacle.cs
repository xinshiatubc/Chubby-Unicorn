using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject cane, caneReversed, candy, candyReversed;
    public List<Color> candyColors = new List<Color>();

    void Start()
    {
        //Assign random rotation degree to candy cane
        RandomRotate(cane);
        RandomRotate(caneReversed);
        //Assign the color palette to candy top
        AssignColour(candy);
        AssignColour(candyReversed);
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

    void AssignColour(GameObject gameObject)
    {
        int randomIndex = Random.Range(0, candyColors.Count);
        gameObject.GetComponent<SpriteRenderer>().color = candyColors[randomIndex];
    }
}
