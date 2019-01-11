using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public int sequences = 0;
    public GameObject door;
    public GameObject eyes;

    private float amount; 

	void Start () {
        amount = 0;
	}
	
	void Update () {
        mainMenuCinematic();

        if (Input.anyKey)
        {
            SceneManager.LoadScene("TensionHouse");
        }
	}

    private void mainMenuCinematic()
    {
        switch (sequences)
        {
            case 0:   
                if (door.transform.rotation.eulerAngles.y < 45)
                {
                    door.transform.Rotate(Vector3.forward, 15 * Time.deltaTime);
                }
                else
                {
                    sequences = 1;
                }
                break;

            case 1:
                eyes.SetActive(true);
                sequences = 2;
                break;

            case 2:
                amount += Time.deltaTime;

                if(amount > 4)
                {
                    sequences = 3;
                    eyes.SetActive(false);
                    amount = 0;
                }
                break;

            case 3:

                if (door.transform.rotation.eulerAngles.y > 1)
                {
                    door.transform.Rotate(Vector3.back, 15 * Time.deltaTime);
                }
                else
                {
                    sequences = 4;
                }
                break;

            case 4:

                amount += Time.deltaTime;

                if(amount > 10)
                {
                    sequences = 0;
                    amount = 0;
                }
                break;


        }
    }
}
