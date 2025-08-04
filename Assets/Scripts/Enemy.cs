using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player,enemy;
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    /****
    =============
    Old Script, Not Deleting for Documentation Purposes, InCase I need it for a diff game.
    =============
    
    **/


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        //Player Direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        //Detect if player is above
        if (isGrounded)
        {
            //Chase player
            rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collission)
    {
        //Enemy enemy = collission.GetComponent<Enemy>();
        if (collission.tag == "Bullet")
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }
}
