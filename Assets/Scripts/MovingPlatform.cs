using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Action
{
    public Vector3 path;
    public bool enable = true;
    public float speed = 1f;
    public float pause = 0f;

    private float way;
    private Transform plyOnPlatform;

    void Start()
    {
        way = 0;

        if(enable == false) return;

        StartCoroutine(Move());
    }

    private IEnumerator Move(){
        Vector3 step;
        while (true)
        {
            if(enable == false) break;

            step = path.normalized * speed * Time.deltaTime;

            transform.Translate(step,Space.World);
            if(plyOnPlatform != null)
                plyOnPlatform.Translate(step,Space.World);


            way += step.magnitude;

            if(way >= path.magnitude){
                way = 0;
                path *= -1;
                yield return new WaitForSeconds(pause);
            }else yield return new WaitForEndOfFrame();
           
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            plyOnPlatform = other.transform;   
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
           plyOnPlatform = null;
        }
    }


    public override void onEnable(){
        enable = true;
        StartCoroutine(Move());
    }
    public override void onDisable(){
        enable = false;
    }
    
    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + path);
    }
}
