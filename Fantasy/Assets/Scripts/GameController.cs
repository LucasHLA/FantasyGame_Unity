using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public LittleWitch witch;
    public int playerHealthAmount;
    public Animator healthPower;
    public static GameController instance;
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthAmount = witch.healthAmount;
        HealthPowerState();
    }

    public void ShowGameOver()
    {
      StartCoroutine(CallGameOver());
    }

    private IEnumerator CallGameOver()
    {
        yield return new WaitForSeconds(.9f);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.6f;
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
    }
}
