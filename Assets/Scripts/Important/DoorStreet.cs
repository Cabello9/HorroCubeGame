using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStreet : MonoBehaviour {

    public GameObject panel;
    public bool green = false;
    public AudioClip scareFinal;

    private float amount;
    private bool amountTrigger = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            if (green)
            {
                FindObjectOfType<LastScareCinematic>().sequences = 0;
                FindObjectOfType<CameraMovement>().movement = false;
                FindObjectOfType<CameraControl>().movement = false;
                amountTrigger = true;
            }
            else
            {
                transform.parent.GetComponent<AudioSource>().Play();
            }

        }

        if (amountTrigger)
        {
            amount += Time.deltaTime;

            if(amount > 2.80f)
            {
                GetComponent<AudioSource>().clip = scareFinal;
                GetComponent<AudioSource>().Play();
                GetComponent<DoorStreet>().enabled = false;
            }
           
        }
    }
}
