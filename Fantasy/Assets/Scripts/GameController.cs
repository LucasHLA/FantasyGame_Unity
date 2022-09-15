using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public LittleWitch witch;
    public int playerHealthAmount;
    [SerializeField] private TextMeshProUGUI HealinghNumber;
    public Animator healthPower;
    public static GameController instance;
    void Start()
    {
        instance = this;
        HealinghNumber.text = playerHealthAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthAmount = witch.healthAmount;
        HealthPowerState();
        HealinghNumber.text = playerHealthAmount.ToString();
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
        else
        {
            healthPower.SetInteger("state", 0);
        }
    }
}
