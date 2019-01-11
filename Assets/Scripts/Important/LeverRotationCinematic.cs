using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotationCinematic : MonoBehaviour {

    public int sequences = -1;

    public GameObject lights;
    public GameObject spotLight;
    public AudioClip leverSound;

	void Start () {
		
	}
	
	void Update () {
        controlRotate();
	}

    private void controlRotate()
    {
        switch (sequences)
        {
            case 0:
                if (transform.rotation.eulerAngles.x < 345 || transform.rotation.eulerAngles.x > 347)
                {
                    transform.Rotate(Vector3.left * 40f * Time.deltaTime);
                }

                if (transform.rotation.eulerAngles.x > 345 && transform.rotation.eulerAngles.x < 347)
                {
                    lights.SetActive(true);
                    FindObjectOfType<DoorStreet>().green = true;
                    spotLight.SetActive(false);
                    FindObjectOfType<ImportantThingsDetection>().lengthDetection = 0.2f;
                    GetComponent<LeverRotationCinematic>().enabled = false;
                }

                break;
        }
    }

    public void playLeverSound()
    {
        GetComponent<AudioSource>().clip = leverSound;
        GetComponent<AudioSource>().Play();
    }
}
