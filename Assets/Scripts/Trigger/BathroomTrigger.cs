using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour {

    public GameObject lampLight;
    public GameObject bedroomLamp;
    public GameObject corridorLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lampLight.GetComponent<Light>().enabled = !lampLight.GetComponent<Light>().enabled;
            corridorLight.GetComponent<Light>().enabled = !corridorLight.GetComponent<Light>().enabled;
            lampLight.GetComponent<AudioSource>().Play();
            corridorLight.GetComponent<AudioSource>().Play();
            bedroomLamp.GetComponent<AudioSource>().Play();
            bedroomLamp.GetComponent<Light>().enabled = !bedroomLamp.GetComponent<Light>().enabled;
            FindObjectOfType<KeyTrigger>().activate = true;
            Destroy(this.gameObject);
        }
    }
}
