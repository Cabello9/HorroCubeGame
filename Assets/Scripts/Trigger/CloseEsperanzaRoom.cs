using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CloseEsperanzaRoom : MonoBehaviour {

    public GameObject lastWall;
    public GameObject postProcessingEsperanza;
    public GameObject postProcessingMaldad;
    public GameObject heart;
    public GameObject creepy;
    public GameObject rain;
    public AudioClip relax;

    private float amount;
    private bool start;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lastWall.SetActive(true);
            postProcessingEsperanza.layer = 10;
            postProcessingMaldad.layer = 0;
            heart.GetComponent<AudioSource>().clip = relax;
            heart.GetComponent<AudioSource>().volume = 0;
            heart.GetComponent<AudioSource>().Play();
            creepy.GetComponent<AudioSource>().Stop();
            rain.GetComponent<AudioSource>().Stop();
            start = true;
        }

    }

    void Update()
    {
        if (start)
        {
            heart.GetComponent<AudioSource>().volume += 0.05f;
        }
    }
}
