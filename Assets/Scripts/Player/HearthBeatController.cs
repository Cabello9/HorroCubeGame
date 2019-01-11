using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthBeatController : MonoBehaviour {

    public int sanity;

    public AudioClip slowHearthBeat;
    public AudioClip normalHearthBeat;

    private int lastSanity;
    private AudioSource audioSource;

    void Awake()
    {
        sanity = 100;
        lastSanity = sanity;
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
		if(sanity != lastSanity)
        {
            changeAudio();
        }
	}

    private void changeAudio()
    {
        if(sanity > 50)
        {
            audioSource.clip = slowHearthBeat;
            audioSource.volume = 0.3f;
            audioSource.Play();
        } else
        {
            audioSource.clip = normalHearthBeat;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
        lastSanity = sanity;
    }
}
