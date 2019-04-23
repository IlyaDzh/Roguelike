using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Характеристики врага")]
    public float HP;
    public GameObject coins;
    
    void Update() 
    {
        if (HP<=0)
        {
            Instantiate(coins, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}