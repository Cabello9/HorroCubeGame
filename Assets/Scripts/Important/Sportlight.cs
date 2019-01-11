using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sportlight : MonoBehaviour {

    public GameObject lantern;
    public GameObject stairsLamp;

	void Start () {
		
	}
	
	void Update () {

        if(Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            lantern.SetActive(true);
            stairsLamp.SetActive(false);
            Destroy(this.gameObject);
        }
		
	}
}
