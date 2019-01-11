using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip hearthBeat;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playHearthBeat()
    {
        audioSource.clip = hearthBeat;
        audioSource.Play();
    }
}
