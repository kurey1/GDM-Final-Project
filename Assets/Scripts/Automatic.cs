using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour
{
    public Transform spike;
    public float dropDistance = 3f;
    public float dropSpeed = 10f;
    public float riseSpeed = 3f;
    public float waitTime = 0.5f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool triggered = false;
    private bool returning = false;

    void Start()
    {
        startPos = spike.position;
        endPos = startPos + Vector3.down * dropDistance;
    }

    void Update()
    {
        if (triggered && !returning)
        {
            spike.position = Vector3.MoveTowards(spike.position, endPos, dropSpeed * Time.deltaTime);

            if (spike.position == endPos)
                StartCoroutine(ReturnUp());
        }

        if (returning)
        {
            spike.position = Vector3.MoveTowards(spike.position, startPos, riseSpeed * Time.deltaTime);

            if (spike.position == startPos)
            {
                triggered = false;
                returning = false;
            }
        }
    }

    private IEnumerator ReturnUp()
    {
        yield return new WaitForSeconds(waitTime);
        returning = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            triggered = true;
    }
}
