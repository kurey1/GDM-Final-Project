using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
    public AudioClip hitSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f);
        }

      
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
                if (fullHeart != null) hearts[i].sprite = fullHeart;
            }
            else
            {
                if (emptyHeart != null)
                {
                    hearts[i].enabled = true;
                    hearts[i].sprite = emptyHeart;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }

    void Die()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}