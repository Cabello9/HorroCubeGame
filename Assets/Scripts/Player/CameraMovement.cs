using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Rigidbody _rB;
    public float moveSpeed;
    public bool movement;
    public int sensitiveX;

	void Start () {
        _rB = GetComponent<Rigidbody>();
        Cursor.visible = false;
	}
	
	void Update () {
        if(movement)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitiveX, 0);
    }

    void FixedUpdate()
    {
        if (movement)
        {
            handleInput();
        }
    }

    private void handleInput()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 despH = transform.right * moveSpeed * h * Time.deltaTime;
        Vector3 despV = transform.forward * moveSpeed * v * Time.deltaTime;

        _rB.MovePosition(_rB.position + despV + despH);
    }
}
