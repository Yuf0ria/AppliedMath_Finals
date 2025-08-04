using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    //float Horizontalmove;
    public Animator anim; // Movement
    public int flipPlayer = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        //rb.linearVelocity = new Vector2(Horizontalmove * moveSpeed, rb.linearVelocity.y);
        //Conditions to flip Player
        if (moveInput > 0 && transform.localScale.x < 0 ||
            moveInput < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        //Animation Movement
        anim.SetFloat("Horizontal", Mathf.Abs(moveInput));
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
    }

    // public void Move(InputAction.CallbackContext context)
    // {
    //     Horizontalmove = context.ReadValue<Vector2>().x;
    // }

    void Flip()
    {
        flipPlayer *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}