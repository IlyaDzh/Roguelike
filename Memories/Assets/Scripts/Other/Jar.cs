using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{
    private bool crash=false;

    void Update()
    {
        if (crash && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "areaDamage")
            crash = true;
        if (other.tag == "Bullet")
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(this);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "areaDamage")
            crash = false;
    }
}
