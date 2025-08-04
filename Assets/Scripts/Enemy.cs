using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;
    /****
    =============
    Old Script, Not Deleting for Documentation Purposes, InCase I need it for a diff game.
    =============
    
    **/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        //Player Direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        //Detect if player is above
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 5f, 1 << player.gameObject.layer);

        if (isGrounded)
        {
            //Chaseplayer
            rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);
            //Jump or no jump...no jump needed
            //if Ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

            //Just Checking this out
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);
            //if player above
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);
            //Conditions for Jumping
            if (!groundInFront.collider && !gapAhead.collider) {
                shouldJump = true;
            }
            else if (isPlayerAbove && platformAbove.collider) {
                shouldJump = true;
            }
        }

    }

    private void FixedUpdate() {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 JumpDirection = direction * jumpForce;
            //rigidbody
            rb.AddForce(new Vector2(JumpDirection.x, jumpForce), ForceMode2D.Impulse); // Applies force physics
        }
    }
}
