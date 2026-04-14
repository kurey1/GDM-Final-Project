using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    public float speed = 2f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public float rayOffsetX = 0.25f; 

    private bool movingRight = true;
    private Rigidbody2D rb;
    private Collider2D enemyCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemyCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(speed * (movingRight ? 1 : -1), rb.linearVelocity.y);

        
        Vector2 origin = (Vector2)transform.position + new Vector2((movingRight ? rayOffsetX : -rayOffsetX), -enemyCollider.bounds.extents.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(origin, Vector2.down * groundCheckDistance, Color.red);

        
        if (hit.collider == null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;

        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}