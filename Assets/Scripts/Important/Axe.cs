using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            FindObjectOfType<InventoryCharacter>().axe = true;
            this.gameObject.SetActive(false);
        }
    }
}
