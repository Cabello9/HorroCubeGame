using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<ImportantThing>().changeColor)
        {
            GetComponentInChildren<WaterDrop>().CancelInvoke("createWater");
            GetComponent<ImportantThing>().highlightNow = false;
            GetComponent<WaterTap>().enabled = false;
        }
    }
}
