using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    [Range(0,7)]
    public float seeDistance;
    [Range(0,5)]
    public float stopDistance;
    [Range(0,3)]
    public float retreatDistance;
    public GameObject projectile;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    void Update()
    {
        Following();
        CheckDeath();
    }

    protected override void Following()
    {
        if (Vector2.Distance (transform.position, target.transform.position) < seeDistance) 
        {
            Attack();
            if (Vector2.Distance(transform.position, target.transform.position) > stopDistance) {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            } 
            else if (Vector2.Distance(transform.position, target.transform.position) < stopDistance && 
                    Vector2.Distance(transform.position, target.transform.position) > retreatDistance) {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.transform.position) < retreatDistance) {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -speed * Time.deltaTime);
            }
        } else {
            Debug.Log("stop");
            //движение
        }
    }

    protected override void Attack()
    {
        if (timeBtwAttack <= 0) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            projectile.GetComponent<EnemyProjectile>().damage = damage;
            timeBtwAttack = startTimeBtwAttack;
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, seeDistance);
    }
}
