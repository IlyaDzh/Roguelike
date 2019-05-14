using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    void Update()
    {
        Following();
        CheckDeath();
        Attack();
    }

    protected override void Following()
    {

    }

    protected override void Attack()
    {

    }
    //Переопределить дальнюю атаку
}
