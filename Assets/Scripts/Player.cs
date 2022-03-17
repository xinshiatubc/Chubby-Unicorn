using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float jumpAmount = 5f;
    float speed = 0.5f;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameController.instance.gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpAmount;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Dead");
        GameController.instance.PlayerDied();

    }
}
