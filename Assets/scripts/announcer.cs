using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class announcer : MonoBehaviour
{
    public Text canvasText1; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableText", 2f);
    }

    // Update is called once per frame
    void DisableText()
    {
        canvasText1.enabled=false; 
    }
}
