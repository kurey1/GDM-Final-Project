using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;   // how far it moves left/right
    public float speed = 2f;          // movement speed

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}