using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    private Transform target;
    [Header("Характеристики врага")]
    public float HP;
    public float speed;
    public float damage;
    [Range(0,4)]
    public float seeDistance;
    [Range(0,1)]
    public float attackDistance;
    private float waitTime, waitTime2;
    public float startWaitTime, startWaitTime2;
    private bool runToRandom=false;
    private float rndX, rndY;
    public int maxDrop;
    public GameObject damageText;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    protected virtual void Following()
    {
        if (Vector2.Distance (transform.position, target.transform.position) < seeDistance) 
        {
            anim.SetBool("Running", true);
            runToRandom=false;
            waitTime=1;
            speed = 1.8f;
            FlipX(target.position.x);
            Attack();
        } else {
            anim.SetBool("Running", false);
            speed = 1.2f;
            if (waitTime <= 0)
            {
                rndX= Random.Range(transform.position.x-5f, transform.position.x+5f);
                rndY= Random.Range(transform.position.y-5f, transform.position.y+5f);
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

    protected virtual void Attack()
    {
        if (Vector2.Distance (transform.position, target.transform.position) > attackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else {
            PlayerStats.HP -= damage;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seeDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void ShowDamage(int damage)
    {
        damageText.GetComponent<TextMesh>().text = "-" + damage;
        Instantiate(damageText, transform.position, Quaternion.identity);
    }

    protected void CheckDeath()
    {
        if (HP<=0)
        {
            int numberDrop = Random.Range(0, maxDrop);
            GameObject drop = GameObject.Find("GOManager").GetComponent<GOManager>().drop[numberDrop];
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}