using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBoss : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    public GameObject explosion;

    void Start() 
    {
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            PlayerStats.HP -= damage;
            Destroy(gameObject);
        }
    } 

    private void OnDestroy() 
    {
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 1f);
    }
}
