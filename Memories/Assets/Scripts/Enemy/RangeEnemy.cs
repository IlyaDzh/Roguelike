using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    public float stopDistance;
    public float retreatDistance;

    void Update()
    {
        Following();
        CheckDeath();
        Attack();
    }

    protected override void Following()
    {
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
    }

    protected override void Attack()
    {

    }
}
