using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
   public bool down = false;
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "Player"){
            Player.LocalPlayer.BlockGravity(true);
            if(down != Player.LocalPlayer.GetGravity()){
                Player.LocalPlayer.SwitchGravity();
            }

        }
    }

    void OnTriggerExit2D(Collider2D obj){
        if(obj.tag == "Player"){
            Player.LocalPlayer.BlockGravity(false);
        }
    }


}
