using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    [Header("Характеристики героя")]
    public float HP;
    public float maxHP;

    void Awake()
    {
        if (playerStats !=null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        HP = maxHP;
    }
}