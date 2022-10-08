using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject particula;
    public GameObject HealthBar;
    public GameObject HealingPower;
    public GameObject PauseScreen;
    public GameObject Portal;
    public LittleWitch witch;
    public int playerHealthAmount;
    [SerializeField] private TextMeshProUGUI HealinghNumber;
    public Animator healthPower;
    public Animator heart;
    public static GameController instance;

    public bool isPaused;
    void Start()
    {
        instance = this;
        HealinghNumber.text = playerHealthAmount.ToString();
        isPaused = false;
        Destroy(Portal, 1f);
        Destroy(particula, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthAmount = witch.healthAmount;
        HealthPowerState();
        HealinghNumber.text = playerHealthAmount.ToString();
        HeartState();
        PauseGame();
    }

    public void ShowGameOver()
    {
      StartCoroutine(CallGameOver());
    }

    private IEnumerator CallGameOver()
    {
        yield return new WaitForSeconds(.9f);
        GameOverPanel.SetActive(true);
        HealthBar.SetActive(false);
        HealingPower.SetActive(false);
        Time.timeScale = 0.6f;
    }

    private void PauseGame()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        else if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseScreen.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
            }
        }



    }

    public void HealthPowerState()
    {
        if (playerHealthAmount >= 1 && playerHealthAmount <= 2)
        {
            healthPower.SetInteger("state", 0);
        }
        else if(playerHealthAmount >= 3 && playerHealthAmount <= 4)
        {
            healthPower.SetInteger("state", 1);
        }
        else if(playerHealthAmount == 5)
        {
            healthPower.SetInteger("state", 2);
        }
        else
        {
            healthPower.SetInteger("state", 0);
        }
    }

    public void HeartState()
    {
        if(witch.health < witch.maxHealth)
        {
            heart.SetInteger("state", 0);
        }
        else if(witch.health  == witch.maxHealth)
        {
            heart.SetInteger("state", 1);
        }
    }
}
