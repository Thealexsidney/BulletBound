using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerMaxHealth;
    public int Coins;
    public float dodgeChance;
    public int playerHealth;
    public float maxSpeed = 5f;

    //Skill Tree Bools
    public bool healthOneBought;
    public bool healthTwoBought;

    public bool speedOneBought;
    public bool speedTwoBought;

    public bool dodgeOneBought;
    public bool dodgeTwoBought;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
