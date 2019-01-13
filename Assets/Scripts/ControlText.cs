using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour {

    public void disableTextCall()
    {
        StartCoroutine(disableText());
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Text>().enabled = false;
    }
}
