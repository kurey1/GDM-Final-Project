using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float moveDistance = 3f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingDown = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.down * moveDistance;
    }

    void Update()
    {
        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

            if (transform.position == endPos)
                movingDown = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
                movingDown = true;
        }
    }
}