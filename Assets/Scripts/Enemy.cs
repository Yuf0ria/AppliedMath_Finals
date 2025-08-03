using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMarsk groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycase(transform.position, Vector2.down, 1f, groundLayer);

        //Player Direction
        float direction = Mathf.Sign(player.position.x = transform.position.x);
    }
}
