using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerBase
{
    public GameObject projectile;
    public int minDamage;
    public int maxDamage;
    public float projectileForce;

    void Update ()
	{
		TakeInput ();
		Move ();
        Attack();
    }

    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
