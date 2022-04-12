using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCube : MonoBehaviour
{
    public bool enable = true;

    public Transform destination;
    public Transform In;
    public Vector3 offSet = Vector3.zero;



    void OnTriggerEnter2D(Collider2D obj){
        if(enable){
            obj.transform.position = destination.position + offSet;
        }
    }



    void OnDrawGizmosSelected()
    {   
        if (destination != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(In.position, destination.position + offSet);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(destination.position + offSet,0.5f);
        }
    }

}
