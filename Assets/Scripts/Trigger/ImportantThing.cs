using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantThing : MonoBehaviour {

    public bool changeColor = false;
    public bool highlightNow = true;

    [ColorUsageAttribute(true, true)]
    public Color edgeColor;

    private void Start()
    {
    }

    void Update () {
        if (changeColor && highlightNow)
        {
            GetComponent<Renderer>().material.SetColor("_ColorSuperficial", edgeColor);

            for(int i = 0; i < transform.childCount; i++)
            {
               transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_ColorSuperficial", edgeColor);  
            }
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_ColorSuperficial", Color.black);

            for (int i = 0; i < transform.childCount; i++)
            {
               transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_ColorSuperficial", Color.black);                    
            }
        }
	}
}
