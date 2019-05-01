using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    public Transform ukaz;

    void Start() 
    {
        ukaz = GameObject.FindGameObjectWithTag("Ukaz").GetComponent<Transform>(); 
        transform.rotation = ukaz.transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyBase>().TakeDamage(damage);
            Destroy(gameObject);
        }
    } 
}
