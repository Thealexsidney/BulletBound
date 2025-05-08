using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;

    public Button healthUpOne;
    public Button healthUpTwo;

    public Button speedUpOne;
    public Button speedUpTwo;

    public Button dodgeOne;
    public Button dodgeTwo;

    public Sprite healthDeactive;
    public Sprite speedDeactive;
    public Sprite dodgeDeactive;

    


    void Start()
    {
        
        healthText.text = "Max Health: " + GameManager.Instance.playerMaxHealth;
        coinsText.text = "Coins: " + GameManager.Instance.Coins;

        if (GameManager.Instance.healthOneBought == true)
        {
            Image healthOneButtonImage = healthUpOne.GetComponent<Image>();
            healthOneButtonImage.sprite = healthDeactive;
        }

        if (GameManager.Instance.healthTwoBought == true)
        {
            Image healthTwoButtonImage = healthUpTwo.GetComponent<Image>();
            healthTwoButtonImage.sprite = healthDeactive;
        }

        if (GameManager.Instance.speedOneBought == true)
        {
            Image speedUpOneButtonImage = speedUpOne.GetComponent<Image>();
            speedUpOneButtonImage.sprite = speedDeactive;
        }

        if (GameManager.Instance.speedTwoBought == true)
        {
            Image speedUpTwoButtonImage = speedUpTwo.GetComponent<Image>();
            speedUpTwoButtonImage.sprite = speedDeactive;
        }

        if (GameManager.Instance.dodgeOneBought == true)
        {
            Image dodgeOneButtonImage = dodgeOne.GetComponent<Image>();
            dodgeOneButtonImage.sprite = dodgeDeactive;
        }

        if (GameManager.Instance.dodgeTwoBought == true)
        {
            Image dodgeTwoButtonImage = dodgeTwo.GetComponent<Image>();
            dodgeTwoButtonImage.sprite = dodgeDeactive;
        }
    }
    public void HealthUp1()
    {
        if (GameManager.Instance.playerMaxHealth < 2)
        {
            if (GameManager.Instance.Coins >= 1)
            {
                GameManager.Instance.Coins -= 1;
                GameManager.Instance.playerMaxHealth++;
                GameManager.Instance.playerHealth++;
                healthText.text = "Max Health: " + GameManager.Instance.playerMaxHealth;
                coinsText.text = "Coins: " + GameManager.Instance.Coins;
                Image healthOneButtonImage = healthUpOne.GetComponent<Image>();
                healthOneButtonImage.sprite = healthDeactive;
                GameManager.Instance.healthOneBought = true;
            }
        }
    }

    public void HealthUp2()
    {
        if (GameManager.Instance.healthOneBought == true)
        {
            if (GameManager.Instance.playerMaxHealth < 3)
            {
                if (GameManager.Instance.Coins >= 2)
                {
                    GameManager.Instance.Coins -= 2;
                    GameManager.Instance.playerMaxHealth++;
                    GameManager.Instance.playerHealth++;
                    healthText.text = "Max Health: " + GameManager.Instance.playerMaxHealth;
                    coinsText.text = "Coins: " + GameManager.Instance.Coins;
                    Image healthTwoButtonImage = healthUpTwo.GetComponent<Image>();
                    healthTwoButtonImage.sprite = healthDeactive;
                    GameManager.Instance.healthTwoBought = true;
                }
            }
        }
        
        
    }

    public void SpeedUp1()
    {
        if (GameManager.Instance.Coins >= 1)
        {
            GameManager.Instance.Coins -= 1;
            GameManager.Instance.maxSpeed += 0.5f;
            coinsText.text = "Coins: " + GameManager.Instance.Coins;
            Image speedUpOneButtonImage = speedUpOne.GetComponent<Image>();
            speedUpOneButtonImage.sprite = speedDeactive;
            GameManager.Instance.speedOneBought = true;
        }

    }

    public void SpeedUp2()
    {
        if (GameManager.Instance.speedOneBought == true)
        {
            if (GameManager.Instance.Coins >= 2)
            {
                GameManager.Instance.Coins -= 2;
                GameManager.Instance.maxSpeed += 0.5f;
                coinsText.text = "Coins: " + GameManager.Instance.Coins;
                Image speedUpTwoButtonImage = speedUpTwo.GetComponent<Image>();
                speedUpTwoButtonImage.sprite = speedDeactive;
                GameManager.Instance.speedTwoBought = true;
            }
        }
    }


    public void dodge1()
    {
        if (GameManager.Instance.Coins >= 1)
        {
            GameManager.Instance.Coins -= 1;
            GameManager.Instance.dodgeChance += 0.05f;
            coinsText.text = "Coins: " + GameManager.Instance.Coins;
            Image dodgeOneButtonImage = dodgeOne.GetComponent<Image>();
            dodgeOneButtonImage.sprite = dodgeDeactive;
            GameManager.Instance.dodgeOneBought = true;
        }
    }

    public void dodge2()
    {
        if (GameManager.Instance.dodgeOneBought == true)
        {
            if (GameManager.Instance.Coins >= 2)
            {
                GameManager.Instance.Coins -= 2;
                GameManager.Instance.dodgeChance += 0.05f;
                coinsText.text = "Coins: " + GameManager.Instance.Coins;
                Image dodgeTwoButtonImage = dodgeTwo.GetComponent<Image>();
                dodgeTwoButtonImage.sprite = dodgeDeactive;
                GameManager.Instance.dodgeTwoBought = true;
            }
        }
    }




}
