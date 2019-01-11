using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySecondFloor : MonoBehaviour {

    public GameObject phone;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
           FindObjectOfType<InventoryCharacter>().keySecondFloor = true;
           phone.GetComponent<Phone>().ring();
           FindObjectOfType<HearthBeatController>().sanity = 50;
            this.gameObject.SetActive(false);
        }
    }
}
