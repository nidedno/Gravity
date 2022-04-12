using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            Player.LocalPlayer.SetPoint();
            AudioManager.instance.Play("StarPickup");
            Destroy(gameObject);
        }
    }
}
