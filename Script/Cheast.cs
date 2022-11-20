using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheast : MonoBehaviour
{
   public  Animator animator;
 
  private void Start() {
    animator= GetComponent<Animator>();
  }
     
    // Start is called before the first frame update
  private void OnTriggerEnter2D(Collider2D other) {
   if(other.gameObject.tag=="Player"){
     PlayerMove playerManager=other.gameObject.GetComponent<PlayerMove>();
        playerManager.point+=100;
        animator.SetTrigger("copen");
        StartCoroutine(WaitSchene());
   }
  }
    IEnumerator WaitSchene()
    {
    yield return new WaitForSeconds(2.5f); 
     Destroy(gameObject);
     }
}
