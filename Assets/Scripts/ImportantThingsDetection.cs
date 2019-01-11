using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantThingsDetection : MonoBehaviour {

    public Camera myEyes;
    public LayerMask importantLayer;
    public float lengthDetection = 0.5f;
    public CursorLockMode lockMode;

    private bool detectImportantThings = false;
    private GameObject lastGameObject;
    private Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
    private RaycastHit hit;

    void Update () {
        detectThings();
        Cursor.lockState = lockMode;
        Screen.fullScreen = true;
        Debug.DrawRay(myEyes.transform.position, myEyes.transform.TransformDirection(Vector3.forward), Color.yellow);
	}

    private void detectThings()
    {

        if (Physics.Raycast(myEyes.transform.position, myEyes.transform.TransformDirection(Vector3.forward), out hit, lengthDetection,importantLayer))
        {
            hit.collider.GetComponent<ImportantThing>().changeColor = true;
            lastGameObject = hit.collider.gameObject;
            detectImportantThings = true;

        }else if(detectImportantThings == true)
        {
            detectImportantThings = false;
            if(lastGameObject != null) lastGameObject.GetComponent<ImportantThing>().changeColor = false;
        }
    }
}
