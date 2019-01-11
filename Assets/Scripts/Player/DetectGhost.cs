using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGhost : MonoBehaviour {

    public LayerMask layerMask;
	
	void Update () {

        if (FindObjectOfType<LastScareCinematic>().sequences == 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 40, layerMask))
            {
                FindObjectOfType<LastScareCinematic>().sequences = 1;
                Destroy(GetComponent<DetectGhost>());
            }
            else
            {
                transform.Rotate(Vector3.down * 40f * Time.deltaTime);
            }
        }
    }
}
