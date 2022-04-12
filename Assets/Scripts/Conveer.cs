using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : Action
{
    public float speed;

    public bool enable = true;
    Rigidbody2D body;
    


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!enable) return;

        Vector2 pos = body.position;
        body.position += Vector2.right * speed * Time.fixedDeltaTime;
        body.MovePosition(pos);
    }

    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.right * Mathf.Sign(speed));
    }

    public override void onEnable() => enable = true;

    public override void onDisable() => enable = false;

}


