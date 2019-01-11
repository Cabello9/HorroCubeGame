using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsperanzaTrigger : MonoBehaviour {

    public Transform spawn;
    public Transform rope;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = spawn.position;
            other.transform.LookAt(rope.transform);
            FindObjectOfType<CameraControl>().movement = false;
            FindObjectOfType<CameraMovement>().movement = false;

        }
    }
}
