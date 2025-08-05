using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //call variables
    public Transform player;
    public float chaseSpeed = 2f;
    public LayerMask groundLayer;
    //Rigidbody of enemy
    private Rigidbody2D rb;
    private bool isGrounded;

    /****
    =============
    Currently used for Enemy AI, connected Scripts:
    - Waypoint
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
        if (collission.tag == "Bullet")
        {
            SoundEffectManager.Play("Hit");
            Destroy(gameObject);
            //Debug.Log("Dead");
        }
    }
}
