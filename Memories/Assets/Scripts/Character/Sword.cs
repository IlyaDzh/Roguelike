using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : PlayerBase
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPoss;
    public LayerMask whatIsEnemies;
    [Range(0,1)]
    public float attackRange;
    public int damage;

    void Update ()
	{
		TakeInput ();
		Move ();
        Attack();
    }

    protected override void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoss.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyStats>().HP -= damage;
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
        Gizmos.DrawWireSphere(attackPoss.position, attackRange);
    }
}