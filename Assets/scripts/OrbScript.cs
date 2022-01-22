using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{ 
    private float Rotation=0; 
     private float speed= 2;
     public AudioSource collect; 
     
     void Start()
     {
         collect=GetComponent<AudioSource>(); 
     }
     void Update()
     {
         if (Rotation==360)
         {
             Rotation=0; 
         }
         Rotation= Rotation+150* Time.deltaTime; 
         gameObject.transform.rotation=Quaternion.Euler(0,0,Rotation); 
         gameObject.transform.Translate(0,speed*Time.deltaTime,0); 
     }
     
     void OnTriggerEnter2D(Collider2D col)
     {
         
        if(col.tag=="Player")
        {
            collect.Play(); 
        }
     }

    
   
   
}
