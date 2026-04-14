using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public EnemyHit enemy; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.Stomp(collision);
        }
    }
}
