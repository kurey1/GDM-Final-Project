using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            if (collision.contacts[0].normal.y < -0.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}