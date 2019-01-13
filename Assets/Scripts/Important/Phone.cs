using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour {

    private float duration;
    private AudioSource audioSource;
    public AudioClip call;

    private float amount = 0;
    private bool noMovement = false;
    public bool triggerStopCall = false;
    private float amountStopCall = 0;
    private bool speaking = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().highlightNow && GetComponent<ImportantThing>().changeColor && !speaking)
        {
            FindObjectOfType<CameraMovement>().movement = false;
            FindObjectOfType<CameraControl>().movement = false;
            GetComponent<ImportantThing>().highlightNow = false;
            FindObjectOfType<HearthBeatController>().sanity = 70;
            speaking = true;
            noMovement = true;
            StartCoroutine(WaitForSound());           
        }

        if (noMovement)
        {
            amount += Time.deltaTime;
            if (amount >= call.length + 2)
            {
                FindObjectOfType<CameraMovement>().movement = true;
                FindObjectOfType<CameraControl>().movement = true;
                Destroy(GetComponent<Phone>());
            }
        }

        if(!noMovement && triggerStopCall)
        {
            amountStopCall += Time.deltaTime;
            
            if(amountStopCall > 20)
            {
                GetComponent<AudioSource>().Stop();
                Destroy(GetComponent<Phone>());
            }
        }
    }

    IEnumerator WaitForSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = call;
        audioSource.Play();  
        yield return new WaitForSeconds(call.length);
    }

    public void ring()
    {
        GetComponent<ImportantThing>().highlightNow = true;
        audioSource.Play();
        triggerStopCall = true;
    }
}
