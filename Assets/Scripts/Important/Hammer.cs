using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour {

    public GameObject phone;
    public GameObject text;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            FindObjectOfType<InventoryCharacter>().hammer = true;
            phone.GetComponent<Phone>().ring();
            phone.GetComponent<Phone>().triggerStopCall = true;

            text.GetComponent<Text>().text = "Lever picked";
            text.GetComponent<Text>().enabled = true;
            text.GetComponent<ControlText>().disableTextCall();

            this.gameObject.SetActive(false);
        }
    }
}
