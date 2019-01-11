using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {

    public bool walk = false;

    private float amount;

	void Update () {

        amount += Time.deltaTime;

        if (walk)
            transform.Translate(Vector3.back * 2f * Time.deltaTime);

        if (amount >= 10f)
            Destroy(this.gameObject);
    }
}
