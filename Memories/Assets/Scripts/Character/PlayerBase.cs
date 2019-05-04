using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [Header("Характеристика героя")]
    public float Speed;
    protected int damage;
    public int minDamage;
    public int maxDamage;
    protected Vector2 direction;
	private Animator animator;
    private Rigidbody2D rb;

    void Start() 
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
	protected virtual void TakeInput()
	{
        direction = Vector2.zero;
        if (Input.GetKey (KeyCode.W)) 
        {
            direction += Vector2.up*0.9f;
        }
        if (Input.GetKey (KeyCode.A)) 
        {
            direction += Vector2.left;
        }
        if (Input.GetKey (KeyCode.S)) 
        {
            direction += Vector2.down*0.9f;
        }
        if (Input.GetKey (KeyCode.D)) 
        {
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Translate(direction);
        }
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || 
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || 
            (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || 
            (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)))
        {
            direction *= 0.8f;
        }
    }

    protected void Move()
	{
		transform.Translate(direction * Speed * Time.deltaTime);
        //rb.velocity = direction * Speed * Time.deltaTime;
        //rb.AddForce(direction * Speed * Time.deltaTime);
		if (direction.x != 0 || direction.y != 0) {
			AnimationMove (direction);
		} else {
			animator.SetLayerWeight (1, 0);
		}
	}

	void AnimationMove(Vector2 direction)
	{
		animator.SetLayerWeight (1, 1);
		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
	}

    protected abstract void Attack();
}