using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; 
    public Rigidbody2D rb; 
    private Vector2 moveDirection; 
    private bool Rightfacing=true; 
    public float currentTime=0f; 
    public float startingTime=10f; 
     int score; 
     public Text lose;
     public Text win; 
     public GameObject ghost; 
    
     
    public Text countdownText; 
    public AudioSource WinLose;
    public AudioClip Win; 
    public AudioClip Lose; 
    public Text scoreValue; 
    
    
    void Start()
    {
        transform.position=new Vector3(0,0,0); 
        currentTime=startingTime; 
        score=0; 
        lose.text=""; 
        win.text=""; 
        
        WinLose=GetComponent<AudioSource>(); 
        scoreValue.text="Score"+score.ToString();
        
        

        
        
    }
    void Update()
     {
         if (Input.GetKeyDown("escape"))
       {
           Application.Quit(); 
       }
       ProcessInputs();  
       if(transform.position.y>=3.8f)
       {
           transform.position=new Vector3(transform.position.x,3.8f,0); 
       }
       else if(transform.position.y<=-3.63f)
       {
           transform.position=new Vector3(transform.position.x, -3.63f,0); 
       }
        if(transform.position.x>=8.05f)
       {
           transform.position=new Vector3(8.05f,transform.position.y,0); 
       }
       else if(transform.position.x<=-7.97)
       {
           transform.position=new Vector3(-7.97f,transform.position.y,0); 
       }
       
       currentTime-=1*Time.deltaTime;
       countdownText.text=currentTime.ToString("0"); 
       if (currentTime<=0)
       {
           currentTime=0; 
           WinLose.clip=Lose; 
           WinLose.Play(); 
           lose.text="You Lose"; 
           Destroy(this); 
           Destroy(gameObject, 2f); 
         
        
           



       }
       else if (score==4)
        {
           
            WinLose.clip=Win; 
            WinLose.Play(); 
            win.text="You Win!"; 
            Destroy(this); 
           Destroy(gameObject, 2f); 

           
        }
        
        
       

       

    }
    void FixedUpdate()
    {
        Move(); 
        
        
       
        if(Rightfacing==false&&moveDirection.x<0)
        {
            Flip();
        }
        else if(Rightfacing==true&&moveDirection.x>0)
        {
            Flip();
        }

        
    }
    void Flip()
    {
        Rightfacing=!Rightfacing;
        Vector2 Scaler=transform.localScale; 
        Scaler.x=Scaler.x*-1; 
        transform.localScale=Scaler; 
    }

    void ProcessInputs()
    {
        float moveX=Input.GetAxisRaw("Horizontal");
        float moveY=Input.GetAxisRaw("Vertical");
        moveDirection= new Vector2(moveX,moveY).normalized; 
    }
    void Move()
    {
        rb.velocity=new Vector2(moveDirection.x*moveSpeed, moveDirection.y*moveSpeed); 
    }
    //notes: 4 sounds, 2 for winnning and losing. one a sound effect and music
    //particle effect required and a time limit required TIME LIMIT COMPLETE. 
     
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.GetComponent<Collider2D>().tag=="Orb")
        {
            score +=1; 
            
            Destroy(collision.GetComponent<Collider2D>().gameObject, 0.05f);
            scoreValue.text="Score"+score.ToString();
            
        }
        
        
   }
   
    
    
    
}
