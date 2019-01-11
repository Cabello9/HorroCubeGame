using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeShaders : MonoBehaviour {

    public Material door;
    public Material doorKnob;
    public Material hangedManLivingRoom;
    public Material eyeHangedManLivingRoom;
    public Material key;
    public Material hangedManSans;
    public Material eyeHangedManSans;
    public Material ropeMaterial;
    public Material eyeSans;

    void Start () {
        door.SetFloat("_Prueba", 0);
        doorKnob.SetFloat("_Prueba", 0);
        hangedManLivingRoom.SetFloat("_Prueba", 0);
        eyeHangedManLivingRoom.SetFloat("_Prueba", 0);
        key.SetFloat("_Prueba", 0);
        hangedManSans.SetFloat("_Prueba", 1);
        eyeHangedManSans.SetFloat("_Prueba", 1);
        ropeMaterial.SetFloat("_Prueba", 0);
        eyeSans.SetFloat("_Prueba", 0);
    }
}
