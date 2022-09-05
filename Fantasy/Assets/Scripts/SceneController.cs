using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void SceneLoader()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }


}
