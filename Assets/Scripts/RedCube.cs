using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.CompareTag("Player")){
            Player.LocalPlayer.Die();
        }
    }
}
