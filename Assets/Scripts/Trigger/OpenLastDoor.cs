using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLastDoor : MonoBehaviour {

    public bool activate;

    public AudioClip openDoor;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {   
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
           
            if (FindObjectOfType<InventoryCharacter>().axe)
            {
                StartCoroutine(openDoorSound());
                GetComponent<OpenLastDoor>().enabled = false;
                GetComponent<ImportantThing>().highlightNow = false;
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    IEnumerator openDoorSound()
    {
        transform.parent.GetComponent<RotateLastDoor>().rotate = true;
        audioSource.clip = openDoor;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
