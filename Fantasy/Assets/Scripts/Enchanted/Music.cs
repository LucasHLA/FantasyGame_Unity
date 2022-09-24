using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    private AudioSource source;
    [SerializeField] private AudioClip music;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.clip = music;
        source.Play();  
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        
        if(musicObj.Length > 1f)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
