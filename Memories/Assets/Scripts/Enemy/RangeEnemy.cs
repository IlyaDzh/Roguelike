using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{
    void Update()
    {
        Following();
    }

    protected override void Attack()
    {
        //дальняя атака
    }
}
