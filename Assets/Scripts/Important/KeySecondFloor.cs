using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySecondFloor : MonoBehaviour {

    public GameObject phone;
    public GameObject text;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            FindObjectOfType<InventoryCharacter>().keySecondFloor = true;
            phone.GetComponent<Phone>().ring();
            FindObjectOfType<HearthBeatController>().sanity = 50;
            text.GetComponent<Text>().text = "Second floor door key picked";
            text.GetComponent<Text>().enabled = true;
            text.GetComponent<ControlText>().disableTextCall();
            this.gameObject.SetActive(false);
        }
    }
}
