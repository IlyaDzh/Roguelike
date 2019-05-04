using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : PlayerBase
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    [Range(0,1)]
    public float attackRange;

    void Update ()
	{
		TakeInput ();
		Move ();
        Attack();
    }

    protected override void TakeInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey (KeyCode.W)) 
        {
            attackPos.position = new Vector2 (transform.position.x, transform.position.y+0.3f);
            direction += Vector2.up*0.9f;
        }
        if (Input.GetKey (KeyCode.A)) 
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y);
            direction += Vector2.left;
        }
        if (Input.GetKey (KeyCode.S)) 
        {
           attackPos.position = new Vector2 (transform.position.x, transform.position.y-0.3f); 
            direction += Vector2.down*0.9f;
        }
        if (Input.GetKey (KeyCode.D)) 
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y);
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y+0.3f);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y+0.3f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y-0.3f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y-0.3f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Translate(direction);
        }
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || 
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || 
            (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || 
            (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)))
        {
            direction *= 0.8f;
        }
    }

    protected override void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                damage = Random.Range(minDamage, maxDamage);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBase>().ShowDamage(damage);
                    enemiesToDamage[i].GetComponent<EnemyBase>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}