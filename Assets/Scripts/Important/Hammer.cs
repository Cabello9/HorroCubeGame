using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    public GameObject phone;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            FindObjectOfType<InventoryCharacter>().hammer = true;
            phone.GetComponent<Phone>().ring();
            phone.GetComponent<Phone>().triggerStopCall = true;
            this.gameObject.SetActive(false);
        }
    }
}
