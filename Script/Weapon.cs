using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform firePoint;
   public GameObject bulet;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
                Shoot();
            
        }
    }
    void Shoot(){
        Instantiate(bulet,firePoint.position,firePoint.rotation);
    }
}
