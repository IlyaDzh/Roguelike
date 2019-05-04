using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    [Header("Характеристики героя")]
    public static float HP;
    public float maxHP;
    public static int coins;

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