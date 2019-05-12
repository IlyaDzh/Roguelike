using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : PlayerBase
{
    private GameObject projectile;
    public float projectileForce;
    public int numberBullet;

    void Update ()
	{
		TakeInput ();
		Move ();
        Attack();
    }

    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        { 
            if (!GameObject.Find("GOManager")) return;
            projectile = GameObject.Find("GOManager").GetComponent<GOManager>().bullet[numberBullet];
            Vector2 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
