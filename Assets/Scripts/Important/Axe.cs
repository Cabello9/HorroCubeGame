using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MonoBehaviour {

    public GameObject text;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            FindObjectOfType<InventoryCharacter>().axe = true;
            text.GetComponent<Text>().text = "First floor key door picked";
            text.GetComponent<Text>().enabled = true;
            text.GetComponent<ControlText>().disableTextCall();
            this.gameObject.SetActive(false);
        }
    }
}
