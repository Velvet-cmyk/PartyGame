using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBound;
    // Start is called before the first frame update
    void Start()
    {
        screenBound=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z ));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos=transform.position;
        viewPos.x=Mathf.Clamp(viewPos.x, screenBound.x, screenBound.x*-1);
        viewPos.y=Mathf.Clamp(viewPos.y,screenBound.y,screenBound.y*-1); 
        transform.position=viewPos; 
    }
}
