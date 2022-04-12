using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : Action
{
   // public Transform platform;
    public Vector3 path;
    
    public float smoothTime;

    private Vector3 velocity;
    private Vector3 startPos;
    private Vector3 way;

    void Start(){
        startPos = transform.position;
        way = transform.position;
    }
    void Update(){
        transform.position = Vector3.SmoothDamp(transform.position, startPos + way, ref velocity, smoothTime);
    }
    public override void onEnable(){
        way = path;
    }
    public override void onDisable(){
        way = Vector3.zero;
    }
}
