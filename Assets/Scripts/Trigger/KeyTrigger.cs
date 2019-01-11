using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour {

    public GameObject key;
    public GameObject hangedMan;
    public GameObject bathroomLight;
    public bool activate;

    private void OnTriggerEnter(Collider other)
    {
        if(activate)
        {
            key.SetActive(true);
            hangedMan.SetActive(false);
            bathroomLight.GetComponent<Light>().color = Color.white;
            bathroomLight.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
