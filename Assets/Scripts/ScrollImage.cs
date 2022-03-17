using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollImage : MonoBehaviour
{
    //set scroll speed to public so we can create the parallax effect
    public float scrollSpeed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //Start the object moving.
        rb2d.velocity = new Vector2(scrollSpeed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        // If the game is over, stop scrolling.
        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
