using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    private Vector2 startPos;
    public float speed;
    [Range(0,3)]
    public float seeDistance;
    [Range(0,1)]
    public float attackDistance;
    bool attacking=false;

    void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);    
    }

    void Update()
    {
        if (Vector2.Distance (transform.position, target.transform.position) < seeDistance) 
        {
            if (Vector2.Distance (transform.position, target.transform.position) > attackDistance)
            {
                attacking=false;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                attacking=true;
                Invoke("Attacking", 0.5f);
            }
        } else {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }

    void Attacking()
    {
        if (attacking)
            Debug.Log("Attack");
    }

    public void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seeDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}