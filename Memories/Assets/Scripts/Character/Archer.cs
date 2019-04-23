using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerBase
{

    void Update ()
	{
		TakeInput ();
		Move ();
        Attack();
    }

    protected override void Attack()
    {
        
    }
}
