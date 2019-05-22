using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerBase
{
    private GameObject projectile;
    public float projectileForce;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

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
            if (Input.GetMouseButton(0) && Time.timeScale == 1)
            { 
                if (!GameObject.FindGameObjectWithTag("GOManager")) return;
                projectile = GameObject.FindGameObjectWithTag("GOManager").GetComponent<GOManager>().bullet[3];
                Vector2 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = transform.position;
                Vector2 direction = (mousePos - myPos).normalized;
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                spell.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);
                timeBtwAttack = startTimeBtwAttack;
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void SpawnSummons()
    {
        
    }
}
