using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [Header("Движение")]
    public float Speed;
    [Header("Атака")]
    public Transform attackPos;
    private Vector2 direction;
	private Animator animator;
    private Rigidbody2D rb;

    void Start () 
	{
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

	protected void TakeInput()
	{
        direction = Vector2.zero;
        if (Input.GetKey (KeyCode.W)) 
        {
            attackPos.position = new Vector2 (transform.position.x, transform.position.y+0.3f);
            direction += Vector2.up*0.9f;
        }
        if (Input.GetKey (KeyCode.A)) 
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y);
            direction += Vector2.left;
        }
        if (Input.GetKey (KeyCode.S)) 
        {
           attackPos.position = new Vector2 (transform.position.x, transform.position.y-0.3f); 
            direction += Vector2.down*0.9f;
        }
        if (Input.GetKey (KeyCode.D)) 
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y);
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y+0.3f);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y+0.3f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            attackPos.position = new Vector2 (transform.position.x-0.3f, transform.position.y-0.3f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            attackPos.position = new Vector2 (transform.position.x+0.3f, transform.position.y-0.3f);
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

    void CheckDeath()
    {
        //Если хп < 0
        //Проиграть анимацию смерти
        //Звук смерти
    }

    protected abstract void Attack();
}