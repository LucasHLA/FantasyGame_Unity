using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public static GameController instance;
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
