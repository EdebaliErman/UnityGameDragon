using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float health=100;
    public float crounthHealth=100;
    public TextMeshProUGUI TMPro;
    public float walk=5f;
    

    public float  jumpPower=3f;
   public float point=0;
   public Animator animator;
    Rigidbody2D rgb;
    Vector3 v3;
   
    
    void Start()
    {
        health=crounthHealth;
        rgb= GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();

    }

    
    void Update()
    {
        TMPro.text=point.ToString();
        //Yürümeye yarar
        v3 = new Vector3(Input.GetAxis("Horizontal"),0f);
        transform.position += v3*walk*Time.deltaTime;

        //zıplamak için
        if(Input.GetButtonDown("Jump")&& Mathf.Approximately(rgb.velocity.y,0))
        {
            
            rgb.AddForce(Vector3.up*jumpPower,ForceMode2D.Impulse);
            animator.SetBool("jumpDo",true);
        }
          if(animator.GetBool("jumpDo")&& Mathf.Approximately(rgb.velocity.y,0))
            {

                animator.SetBool("jumpDo",false);
            }
    
      

            if(Input.GetAxisRaw("Horizontal")==-1)
            {
                transform.rotation=Quaternion.Euler(0f,180f,0f);
                
            }
            
            if(Input.GetAxisRaw("Horizontal")==1)
            {
                transform.rotation=Quaternion.Euler(0f,0f,0f);
                
            }

            if(Input.GetAxis("Horizontal")<0 ||Input.GetAxis("Horizontal")>0)
            {
                animator.SetBool("walk",true);                    
            }
            else{
                animator.SetBool("walk",false);                    
                    
            }
            if(Input.GetKeyDown(KeyCode.X)){
                animator.SetBool("attack",true);
            }
            else{
                animator.SetBool("attack",false);
            }

            if(Input.GetKeyDown(KeyCode.X)&& Mathf.Approximately(rgb.velocity.y,0))
                {
                    animator.SetBool("jumpAttack",true);
                }
                else{
                    animator.SetBool("jumpAttack",false);
                }

          

            if(crounthHealth==0 || crounthHealth <0)
            {       

                  
               animator.SetBool("dead",true);
              if(animator.GetBool("dead")){
                  StartCoroutine(WaitSchene());
              }
            }  
    
    
    }
    private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag=="Enemy"){
              animator.SetBool("hurt",false);
              
                TakeDamage();
               
            }
        }
    private void TakeDamage(){
        crounthHealth -=20;
         if(Input.GetAxisRaw("Horizontal")==-1)
            {
        gameObject.transform.position=new Vector3(gameObject.transform.position.x+4.5f,gameObject.transform.position.y+3f,gameObject.transform.position.z);
            }
            
         if(Input.GetAxisRaw("Horizontal")==1)
            {
        gameObject.transform.position=new Vector3(gameObject.transform.position.x-4.5f,gameObject.transform.position.y+3f,gameObject.transform.position.z);
            }
        animator.SetTrigger("hurt");
     }
    IEnumerator WaitSchene()
    {
    yield return new WaitForSeconds(1.55f); 
    SceneManager.LoadScene(1);
    }
       
}
