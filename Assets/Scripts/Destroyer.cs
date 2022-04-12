using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag != "Player")
        {
            Destroy(obj.gameObject);
        }
    }
}
