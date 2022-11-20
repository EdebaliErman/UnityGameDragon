using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class See : MonoBehaviour
{      public float damage=1000;
    // Start is called before the first frame update
   
     private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag.Equals("Player")){
        Player playerManager=other.gameObject.GetComponent<Player>();
        playerManager.crounthHealth-=damage;
     }
   }
   
}
