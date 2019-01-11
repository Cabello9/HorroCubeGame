using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public float speed;
    public float lifeTime;

	void Start () {
        Invoke("destroy", lifeTime);
	}
	
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

    private void destroy()
    {
        Destroy(this.gameObject);
    }
}
