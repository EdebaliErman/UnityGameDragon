using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health=100;
    
     PlayerMove _player; 
    void Start() {
              _player= GameObject.FindObjectOfType<PlayerMove>();
                    }

    private void Update() {
        if(health==0){
            _player.point+=25;
            Destroy(gameObject);
        }
    }
 
   
}
