using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerBase
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
