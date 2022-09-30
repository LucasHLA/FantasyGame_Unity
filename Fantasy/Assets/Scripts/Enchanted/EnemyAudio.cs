using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private float volume;

    public AudioClip redGreenSlimeHit;
    public AudioClip blueSlimeDeath;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = volume;
    }

    public void PlaySFX(AudioClip sfx)
    {
        audio.PlayOneShot(sfx);
    }
}
