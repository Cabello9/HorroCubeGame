using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {

    public GameObject water;

	void Start () {
        InvokeRepeating("createWater", 0f, 0.5f);
	}

    private void createWater()
    {
        Instantiate(water, transform.position, transform.rotation);
        GetComponent<AudioSource>().Play();
    }
	
}
