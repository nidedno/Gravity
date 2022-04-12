using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCube : MonoBehaviour
{
    public Transform moving;
    public Vector3 way;
    public float smoothTime = 1f;
    
    public Vector3 gizmoStart;
    private Vector3 velocity;
    private bool active = false;
    void OnTriggerEnter2D(Collider2D obj){
      //  if(obj.CompareTag("Player")){
            active = true;
       // }
    }

    void OnDrawGizmosSelected()
    {   
        if (moving != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(gizmoStart,gizmoStart + way);

        }
    }

    void Update(){
        if(active){
            moving.position = Vector3.SmoothDamp(moving.position, way, ref velocity, smoothTime);
        }
    }

}
