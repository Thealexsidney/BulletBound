using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;

    private bool isPaused = false;
    
    public TextMeshProUGUI healthText;

    
    public TextMeshProUGUI coinsText;

    public GameObject pauseMenu;
    
    public float timeAlive;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI statsText;
    

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        GameManager.Instance.playerHealth = GameManager.Instance.playerMaxHealth;
        healthText.text = "Health: " + GameManager.Instance.playerHealth + "/" + GameManager.Instance.playerMaxHealth;
        coinsText.text = "Coins: " + GameManager.Instance.Coins;
        timeAlive = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosistion(GameManager.Instance.maxSpeed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        timeAlive =  timeAlive + 1*Time.deltaTime;
        timeText.text = "Time: " + timeAlive.ToString("F2");

        statsText.text = "Max Health: " + GameManager.Instance.playerMaxHealth + "\nMax Speed: " + GameManager.Instance.maxSpeed + "\nDodge: " + GameManager.Instance.dodgeChance;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseMenu.SetActive(isPaused);
    }

    private void FollowMousePosistion(float maxSpeed)
    {
        
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Difference = WorldPoint - transform.position;
        Difference.Normalize();

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;
        
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
        
        if (direction.magnitude > 0.00001f)
        {
            if (!isPaused)
            {
                float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, RotationZ - 90);
            }
            
        }
                        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (Random.value > GameManager.Instance.dodgeChance)
            {
                GameManager.Instance.playerHealth--;
                                
                healthText.text = "Health: " + GameManager.Instance.playerHealth + "/" + GameManager.Instance.playerMaxHealth;

                if (GameManager.Instance.playerHealth <= 0)
                {
                    SceneManager.LoadScene("SkillTree");
                    GameManager.Instance.playerHealth = GameManager.Instance.playerMaxHealth;
                }
            }
            
            Destroy(other.gameObject);

        }
        if (other.CompareTag("Laser"))
        {
            if (Random.value > GameManager.Instance.dodgeChance)
            {
                GameManager.Instance.playerHealth--;

                healthText.text = "Health: " + GameManager.Instance.playerHealth + "/" + GameManager.Instance.playerMaxHealth;

                if (GameManager.Instance.playerHealth <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                    GameManager.Instance.playerHealth = GameManager.Instance.playerMaxHealth;
                }
            }

            

        }
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.Coins++;
            Destroy(other.gameObject);
            coinsText.text = "Coins: " + GameManager.Instance.Coins;
        }
        if (other.CompareTag("Heal"))
        {
            if (GameManager.Instance.playerHealth < GameManager.Instance.playerMaxHealth)
            {
                GameManager.Instance.playerHealth++;
                Destroy(other.gameObject);
                healthText.text = "Health: " + GameManager.Instance.playerHealth + "/" + GameManager.Instance.playerMaxHealth;
            }
            
        }

    }
    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    public void Quit()
    {
        Application.Quit();
    }

    

}
