using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    Rigidbody2D rgb;
    public float endTime;
    public float bulletSpeed;
    public float damage;
    public GameObject bulletImpact;
  
    // Start is called before the first frame update
    void Start()
    {

        rgb = GetComponent<Rigidbody2D>();
        rgb.velocity=transform.right*bulletSpeed;
        Destroy(gameObject,endTime);
        
        
    }

    // Update is called once per frame
   private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.CompareTag("Enemy")){
        EnemyMinator enemy= collision.gameObject.GetComponent<EnemyMinator>();
        enemy.health-=damage;
     
        
      
         Destroy(gameObject);
             GameObject delete=Instantiate(bulletImpact,transform.position,transform.rotation);
    Destroy(delete,0.333f);
    }

   }
}
