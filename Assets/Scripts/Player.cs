using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float jumpAmount = 5f;
    private float speed = 0.5f;
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

        if (!GameController.instance.gameOver && Time.timeScale == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpAmount;
            FindObjectOfType<AudioManager>().PlayAudio("Jump");

        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Dead");
        if(!GameController.instance.gameOver)
            GameController.instance.PlayerDied();

    }
}
