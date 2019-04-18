using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    private Transform target;
    private Vector2 startPos;
    public float speed;
    [Range(0,3)]
    public float seeDistance;
    [Range(0,1)]
    public float attackDistance;
    bool attacking=false;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = new Vector2(transform.position.x, transform.position.y);    
    }

    void Update()
    {
        Following();
    }

    void Following()
    {
        if (Vector2.Distance (transform.position, target.transform.position) < seeDistance) 
        {
            Running();
            if (Vector2.Distance (transform.position, target.transform.position) > attackDistance)
            {
                attacking=false;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                attacking=true;
                Invoke("Attacking", 0.5f);
            }
        } else {
            if (startPos.x < transform.position.x)
            {
                sr.flipX=true;
            } else {
                sr.flipX=false;
            }
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        if (transform.position.x == startPos.x && transform.position.y == startPos.y)
        {
            anim.SetBool("Running", false);
        }
    }

    void Attacking()
    {
        if (attacking)
            Debug.Log("Attack");
    }

    void Running()
    {
        anim.SetBool("Running", true);
        if (target.position.x < transform.position.x)
        {
            sr.flipX=true;
        } else {
            sr.flipX=false;
        }
    }

    public void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seeDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}