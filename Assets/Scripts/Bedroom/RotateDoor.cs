using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour {

    public bool rotate = false;
	
	void Update () {
     
        if(transform.rotation.eulerAngles.y < 90 && rotate)
        {
            transform.Rotate(Vector3.forward, 15 * Time.deltaTime);
        }

        
	}
}
    