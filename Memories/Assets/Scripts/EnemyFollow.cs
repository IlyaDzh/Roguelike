using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    private Transform target;
    public float speed;
    [Range(0,3)]
    public float seeDistance;
    [Range(0,1)]
    public float attackDistance;
    private float waitTime, waitTime2;
    public float startWaitTime, startWaitTime2;
    private bool runToRandom=false;
    private float rndX, rndY;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    void Update()
    {
        Following();
    }

    void Following()
    {
        if (Vector2.Distance (transform.position, target.transform.position) < seeDistance) 
        {
            anim.SetBool("Running", true);
            runToRandom=false;
            waitTime=1;
            speed = 1.8f;
            FlipX(target.position.x);
            if (Vector2.Distance (transform.position, target.transform.position) > attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                Debug.Log("Attack");
            }
        } else {
            speed = 1.2f;
            if (waitTime <= 0)
            {
                rndX= Random.Range(-10f, 10f);
                rndY= Random.Range(-10f, 10f);
                FlipX(rndX);
                runToRandom=true;
                waitTime=startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }

        if (runToRandom)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2 (rndX, rndY), speed * Time.deltaTime);
            anim.SetBool("Running", true);
            if (waitTime2 <= 0)
            {
                anim.SetBool("Running", false);
                runToRandom=false;
                waitTime2=startWaitTime2;
            } else {
                waitTime2 -= Time.deltaTime;
            }
        }
    }

    void FlipX(float other)
    {
        if (other < transform.position.x)
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