using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    public Camera MCam; //be sure to assign this in the inspector to your main camera
    
    public float tp_range = 0.3f;
    private Vector2 screenBounds;
    private float objWidth,objHeight;
    public LayerMask mask;
    void Start()
    {
        screenBounds = MCam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,MCam.transform.position.z));
        objHeight = transform.GetComponent<CapsuleCollider2D>().size.y ;
        objWidth =  transform.GetComponent<CapsuleCollider2D>().size.x ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Border();
        BorderTeleport();
       // Debug.Log(screenBounds); 3,9  5


    }

    void Border(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 , screenBounds.x );
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 , screenBounds.y );
        transform.position = viewPos;
    }

    void BorderTeleport(){
        
        if(  ( screenBounds.x - Mathf.Abs(transform.position.x)  ) <= tp_range  ){
            Vector3 newX = new Vector3(-transform.position.x + Mathf.Sign(transform.position.x)*objWidth,transform.position.y,0);

            
            if(Physics2D.OverlapBox(newX,new Vector2(objWidth,objHeight),0,mask) == null){
                transform.position = newX;
            }
        }
        if(  ( screenBounds.y - Mathf.Abs(transform.position.y)  ) <= tp_range  ){
            Vector3 newY = new Vector3(transform.position.x,-transform.position.y + Mathf.Sign(transform.position.y)*objHeight,0);
            
            
            if(Physics2D.OverlapBox(newY,new Vector2(objWidth,objHeight),0,mask) == null){
                transform.position = newY;
            }
        }


  
    }


    

    
}
