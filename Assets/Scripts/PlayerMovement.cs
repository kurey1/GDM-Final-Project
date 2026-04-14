using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator anim;
    private Transform spriteTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        anim = GetComponentInChildren<Animator>();
        spriteTransform = transform.GetChild(0);
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        
        if (move > 0)
            spriteTransform.localScale = new Vector3(1, 1, 1);
        else if (move < 0)
            spriteTransform.localScale = new Vector3(-1, 1, 1);

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        
        anim.SetBool("isRunning", move != 0);
        anim.SetBool("isJumping", Mathf.Abs(rb.linearVelocity.y) > 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}