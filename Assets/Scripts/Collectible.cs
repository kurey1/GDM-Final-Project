using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (collectSound != null)
            {
                
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}