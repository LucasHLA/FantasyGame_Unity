using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public static GameController instance;

    private float showTime;
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
    }
}
