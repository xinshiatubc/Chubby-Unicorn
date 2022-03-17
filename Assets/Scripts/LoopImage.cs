using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImage : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private float width; // image width        

    //Awake is called before Start.
    private void Awake()
    {
        //Store the width of the box collider
        boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x;
    }

    //Update runs once per frame
    private void Update()
    {
        // if the object is no longer visible, move it forward to be re-used
        if (transform.position.x < -width)
        {
            RepositionBackground();
        }
    }

    //Moves the object to double its length.
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
