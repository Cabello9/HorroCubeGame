using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScareCinematic : MonoBehaviour {

    public int sequences = -1;
    public bool playerBody;

    public Material bodyMaterial;
    public Material eyesMaterial;
    public Material doorMaterial;
    public Material pomoMaterial;
    public Material eyeSans;
    public GameObject eyeToChange;
    public GameObject door;
    public GameObject pomo;
    public GameObject ghostBody;
    public GameObject head;
    public GameObject phone;
    public GameObject whiteDoor;
    public AudioClip lastCallClip;
    public AudioClip ring;
    public float firstAngle;

    private float amountShader = 1;
    private float amount = 0;
    
	void Start () {
       firstAngle =  head.transform.eulerAngles.x;
	}
	
	void Update () {
        cinematic();
	}

    private void cinematic()
    {
        switch (sequences){

            case 1:
                amountShader -= 0.5f * Time.deltaTime;
                bodyMaterial.SetFloat("_Prueba", amountShader);
                eyesMaterial.SetFloat("_Prueba", amountShader);

                if (amountShader <= 0)
                {
                    calling();
                    sequences = 2;
                }
                break;

            case 2:

                amount += Time.deltaTime;

                if(amount > 1.5f)
                {
                    sequences = 3;
                    amount = 0;
                }
                break;

            case 3:

                head.transform.Rotate(Vector3.left * 20f * Time.deltaTime);

                if(head.transform.eulerAngles.x < 0)
                {
                    lastRing();
                    sequences = 4;
                    eyeToChange.GetComponent<MeshRenderer>().material = eyeSans;
                    amount = 0;
                }
                break;

            case 4:

                amount += Time.deltaTime;

                if(amount > 3)
                {
                    head.transform.Rotate(Vector3.right * 20f * Time.deltaTime);
                }

                if (head.transform.eulerAngles.x > firstAngle)
                {
                    sequences = 5;
                    amountShader = 0;
                    bodyMaterial.SetFloat("_Prueba", 0);
                    eyesMaterial.SetFloat("_Prueba", 0);
                }
                break;

            case 5:

                amountShader += Time.deltaTime * 0.5f;
                bodyMaterial.SetFloat("_Prueba", amountShader);
                eyesMaterial.SetFloat("_Prueba", amountShader);
                eyeSans.SetFloat("_Prueba", amountShader);

                if (amountShader > 0.8f)
                {
                    phone.GetComponent<AudioSource>().Stop();
                    sequences = 6;
                    pomo.GetComponent<MeshRenderer>().material = pomoMaterial;
                    pomoMaterial.SetFloat("_Prueba", 0);
                    doorMaterial.SetFloat("_Prueba", 0);
                }
                break;

            case 6:

                amountShader += Time.deltaTime * 0.3f;
                doorMaterial.SetFloat("_Prueba", amountShader);
                pomoMaterial.SetFloat("_Prueba", amountShader);

                if (amountShader >= 0.8f)
                {
                    door.SetActive(false);
                    FindObjectOfType<CameraMovement>().movement = true;
                    FindObjectOfType<CameraControl>().movement = true;
                    whiteDoor.SetActive(true);
                    Destroy(GetComponent<LastScareCinematic>());
                }
                break;
        }
    }

    private void lastRing()
    {
        phone.GetComponent<AudioSource>().clip = lastCallClip;
        phone.GetComponent<AudioSource>().Play();
    }

    private void calling()
    {
        phone.GetComponent<AudioSource>().clip = ring;
        phone.GetComponent<AudioSource>().Play();
    }
}
