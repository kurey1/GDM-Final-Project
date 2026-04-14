using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    
    public AudioClip stompSound;

    public void Stomp(Collider2D player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f);

        
        if (stompSound != null)
        {
            AudioSource.PlayClipAtPoint(stompSound, transform.position);
        }

        Destroy(gameObject);
    }
}