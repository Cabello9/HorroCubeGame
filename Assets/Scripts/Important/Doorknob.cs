using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknob : MonoBehaviour {

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
            if (FindObjectOfType<InventoryCharacter>().keySecondFloor)
            {
                StartCoroutine(openDoorSound());
                GetComponent<ImportantThing>().highlightNow = false;
                GetComponent<Doorknob>().enabled = false;
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    IEnumerator openDoorSound()
    {
        transform.parent.GetComponent<RotateDoor>().rotate = true;
        audioSource.clip = openDoor;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
