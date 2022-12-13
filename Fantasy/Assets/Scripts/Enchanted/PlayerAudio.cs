using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float volume;

    public AudioClip magicSpell;
    public AudioClip attack;
    public AudioClip jump;
    public AudioClip footSteps;
    public AudioClip heal;
    public AudioClip slimeHit;
    public AudioClip blueSlimeHit;
    public AudioClip dialogueSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    
    void Update()
    {
        audioSource.volume = volume;
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
