using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLastDoor : MonoBehaviour {

    public bool rotate = false;

    void Update()
    {
        if (transform.rotation.z > -0.705f && rotate)
        {
        transform.Rotate(Vector3.back, 15 * Time.deltaTime);
        }


    }
}
