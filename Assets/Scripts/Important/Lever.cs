using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public GameObject panel;
    public GameObject children;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            if (FindObjectOfType<InventoryCharacter>().hammer)
            {
                panel.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
                children.SetActive(true);
                GetComponent<LeverRotationCinematic>().sequences = 0;
                GetComponent<LeverRotationCinematic>().playLeverSound();
                GetComponent<ImportantThing>().highlightNow = false;
                GetComponent<Lever>().enabled = false;
            }
            else
            {
                GetComponent<AudioSource>().Play();
            }  
        }
    }
}
