using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase
{
    public int numberOfProjectiles;
	public GameObject projectile;
	public float radius;
    public float moveSpeed;

	void Start() 
	{
		sl.maxValue = HP;
        sl.value = HP;  
		Attack();
	}

    void Update() 
    {
        Following();
        CheckDeath();
    }

	IEnumerator SpawnProjectiles(int numberOfProjectiles)
	{
		while(true)
		{
			float angleStep = 360f / numberOfProjectiles;
			float angle = 0f;

			for (int i = 0; i <= numberOfProjectiles - 1; i++) 
			{
				
				float projectileDirXposition = transform.position.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
				float projectileDirYposition = transform.position.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

				Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
				Vector2 tp = new Vector2 (transform.position.x, transform.position.y);
				Vector2 projectileMoveDirection = (projectileVector - tp).normalized * moveSpeed;

				var proj = Instantiate (projectile, transform.position, Quaternion.identity);
				projectile.GetComponent<ProjectileBoss>().damage = damage;
				proj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

				angle += angleStep;
			}

			yield return new WaitForSeconds(3f);
		}
	}

    protected override void Attack()
    {
        StartCoroutine(SpawnProjectiles (numberOfProjectiles));
		//другие корутины
    }

    protected override void Following()
    {
        //движение босса
    }
}