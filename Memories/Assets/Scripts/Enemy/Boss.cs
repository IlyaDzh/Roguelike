using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase
{
    void Update() 
    {
        Following();
        CheckDeath(5);
    }

    protected override void Attack()
    {
        //особая атака
    }

    protected override void Following()
    {
        //особое движение
    }
}
