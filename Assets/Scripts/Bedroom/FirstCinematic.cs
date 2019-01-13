using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCinematic : MonoBehaviour {

    public GameObject player;
    public GameObject door;
    public GameObject bathroomDoor;
    public int sequences;
    public GameObject instructionsObject;
    public GameObject bedroomLight;

    private float amount;

    void Start () {
        sequences = -1;
        amount = 0;
        FindObjectOfType<CameraMovement>().movement = false;
        FindObjectOfType<CameraControl>().movement = false;
        Invoke("bedroomLightOff", 1.5f);
	}
	
	void Update () {
        animations();
	}

    private void startSequence()
    {
        sequences = 0;
    }

    private void bedroomLightOff()
    {
        bedroomLight.GetComponent<Light>().enabled = !bedroomLight.GetComponent<Light>().enabled;
        bedroomLight.GetComponent<AudioSource>().Play();
        door.GetComponent<RotateDoor>().rotate = true;
        door.GetComponent<AudioSource>().Play();
        FindObjectOfType<HearthBeatController>().sanity = 25;
        Invoke("startSequence", 0.5f);
    }

    private void bedroomLightOn()
    {
        bedroomLight.GetComponent<Light>().enabled = !bedroomLight.GetComponent<Light>().enabled;
        bedroomLight.GetComponent<AudioSource>().Play();
        player.GetComponent<CameraMovement>().movement = true;
        player.GetComponentInChildren<CameraControl>().movement = true;
        bathroomDoor.GetComponent<RotateDoor>().rotate = true;
        FindObjectOfType<HearthBeatController>().sanity = 50;
    }

    private void animations()
    {
        switch (sequences){
            case 0:
                if (player.transform.rotation.eulerAngles.y > 225 || player.transform.rotation.eulerAngles.y < 223)
                {
                    player.transform.Rotate(Vector3.down * 40f * Time.deltaTime);
                }

                if (player.transform.rotation.eulerAngles.y < 225 && player.transform.rotation.eulerAngles.y > 223)
                {
                    amount += Time.deltaTime;

                    if (amount > 2f)
                    {
                        amount = 0;
                        sequences = 1;
                    }
                }
                break;

            case 1:

                if (player.transform.rotation.eulerAngles.y > 222 && player.transform.rotation.eulerAngles.y < 358)
                {
                    player.transform.Rotate(Vector3.up * 40f * Time.deltaTime);
                }

                if (player.transform.rotation.eulerAngles.y > 356 && player.transform.rotation.eulerAngles.y < 358)
                {
                    Invoke("bedroomLightOn", 0f);
                    sequences = -1;
                    StartCoroutine(instructions());
                }
                break;
        }
    }

    IEnumerator instructions()
    {
        instructionsObject.GetComponent<Text>().text = "WASD to move";
        instructionsObject.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(4f);

        instructionsObject.GetComponent<Text>().text = "Move the camera with the mouse";
        yield return new WaitForSeconds(4f);

        instructionsObject.GetComponent<Text>().text = "Left mouse button to interact with some objects";
        yield return new WaitForSeconds(4f);

        instructionsObject.GetComponent<ControlText>().disableTextCall();
        gameObject.SetActive(false);
    }
}
