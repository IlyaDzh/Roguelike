using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private bool colWithSpike;

    void Update()
    {
        if (colWithSpike) PlayerStats.HP -= 0.1f;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Spike")
        {
            colWithSpike = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Spike")
        {
            colWithSpike = false;
        }
    }
}
