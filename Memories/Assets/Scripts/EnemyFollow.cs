using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    private Vector2 startPos;
    public float speed;
    public float stopRange;
    public bool follow;

    void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    void Update()
    {
        if (follow)
        {
            if (Vector2.Distance(transform.position, target.position) > stopRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            follow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            follow = false;
        }
    }
}