using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour {

    public LayerMask layerMask;
	
	void Update () {

        if(FindObjectOfType<ScareLivingRoom>().complete)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,40, layerMask))
            {
                FindObjectOfType<ScareLivingRoom>().sequences = 0;
                Destroy(GetComponent<HeadTrigger>());
            }
            else
            {
                transform.Rotate(Vector3.right * 40f * Time.deltaTime);
            }
        }
    }
}
