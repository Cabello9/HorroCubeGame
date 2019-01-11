using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareLivingRoom : MonoBehaviour {

    public GameObject hangedManBody;
    public GameObject hangedManBodyWihoutRope;
    public GameObject character;
    public GameObject hangedMandHead;
    public GameObject rope;
    public Material hangedManMaterial;
    public Material keyMaterial;
    public Material eyesMaterial;
    public bool complete = false;
    public GameObject allCharacter;
    public GameObject pointLight;

    public int sequences = -1;
    private float amountShader = 0;
    private float distance;
    private float distanceShader = 0;


    void Awake()
    {
        keyMaterial.SetFloat("_Prueba", 0);
        hangedManMaterial.SetFloat("_Prueba", 0);
        eyesMaterial.SetFloat("_Prueba", 0);
    }

    void Update () {
       cinematic();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            complete = true;
            FindObjectOfType<CameraControl>().movement = false;
            FindObjectOfType<CameraMovement>().movement = false;
            allCharacter.transform.LookAt(hangedManBody.transform.position);
            character.GetComponent<ScreenShake>().shakeDuration = 8;
            GetComponent<AudioSource>().Play();
            hangedManBody.GetComponent<AudioSource>().Stop();
            pointLight.SetActive(false);
        }
    }

    private void cinematic()
    {
        switch (sequences)
        {

            case 0:  
                distance = Vector3.Distance(character.transform.position, hangedManBody.transform.position) + 0.2f;
                distance = distance / 5f;
                distanceShader = 1f / 5f;
                sequences = 1;

                break;

            case 1:

                amountShader += distanceShader * Time.deltaTime;
                keyMaterial.SetFloat("_Prueba", amountShader);
                hangedManMaterial.SetFloat("_Prueba", amountShader);
                eyesMaterial.SetFloat("_Prueba", amountShader);

                hangedManBody.transform.Translate(Vector3.forward * distance * Time.deltaTime);

                if(amountShader >= 0.8)
                {
                    hangedManBodyWihoutRope.SetActive(false);
                    FindObjectOfType<CameraControl>().movement = true;
                    FindObjectOfType<CameraMovement>().movement = true;
                    rope.AddComponent<Rigidbody>();
                    sequences = -1;
                    pointLight.SetActive(true);
                    Destroy(this.gameObject);
                }

                break;


        }
    }
}
