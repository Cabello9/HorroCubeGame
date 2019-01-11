using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {
	
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
        }
	}
}
