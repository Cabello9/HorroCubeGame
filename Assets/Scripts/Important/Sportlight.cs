using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sportlight : MonoBehaviour {

    public GameObject lantern;
    public GameObject lanternSpotLight;
    public GameObject text;

	void Start () {
		
	}
	
	void Update () {

        if(Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            lantern.SetActive(true);
            lanternSpotLight.SetActive(false);
            text.GetComponent<Text>().text = "Flashlight picked";
            text.GetComponent<Text>().enabled = true;
            text.GetComponent<ControlText>().disableTextCall();
            this.gameObject.SetActive(false);
        }
		
	}
}
