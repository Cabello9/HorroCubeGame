using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EsperanzaHanged : MonoBehaviour {

    public GameObject pomo;
    public AudioClip pomPom;
    public Material ropeMaterial;

    private float amount = 0;
    private bool goal = false;
    private bool complete = false;
    private float amountShader = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        goal = true;
    }

    private void Update()
    {
        if (goal){
            amount += Time.deltaTime;

            if(amount > 3)
            {
                if (!complete)
                {
                    pomo.GetComponent<AudioSource>().clip = pomPom;
                    pomo.GetComponent<AudioSource>().Play();
                    complete = true;
                }

                amountShader += Time.deltaTime * 0.3f;
            }

            ropeMaterial.SetFloat("_Prueba", amountShader);

            if(amount > 6)
            {
                SceneManager.LoadScene("MainMenu");
                
            }
        }
    }
}
