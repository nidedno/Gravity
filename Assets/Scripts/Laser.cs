using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser 
{
    Vector2 pos,dir;
    GameObject laserObj;
    LineRenderer laser;
    GameObject effect;
    List<Vector2> laserIndices = new List<Vector2>();
    private bool iswork = true;

    public Laser(Vector2 pos, Vector2 dir,GameObject effect,Material mat, string name)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = name;
        this.effect = effect;
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.2f;
        this.laser.endWidth = 0.1f;
        this.laser.material = mat;
        this.laser.startColor = Color.red;
        this.laser.endColor = Color.red;
        
        CastRay(pos,dir,laser);
    }

    void CastRay(Vector2 pos,Vector2 dir, LineRenderer laser, int maxLasers = 78)
    {
        if(!iswork) return; 
        if(maxLasers <= 0) return;

        laserIndices.Add(pos);

        Ray2D ray = new Ray2D(pos,dir);
        RaycastHit2D hit = Physics2D.Raycast(pos,dir,30);

        if(hit)
        {
            CheckHit(hit,dir,laser,maxLasers - 1);
        }
        else
        {
            laserIndices.Add(dir*100f);
            DrawLaser();
        }
    }

    void CheckHit(RaycastHit2D hit,Vector2 dir, LineRenderer laser , int maxLasers)
    {
        if(hit.collider.gameObject.tag == "Mirror")
        {
            Vector2 reflect = Vector3.Reflect(dir,hit.normal);
            Vector2 pos = hit.point + reflect * .01f;;
            CastRay(pos,reflect,laser,maxLasers - 1);

        }
        else
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                iswork = false;
                Player.LocalPlayer.Die();
            }

                
            laserIndices.Add(hit.point);
            effect.transform.position = hit.point;
            DrawLaser();

        }
    }

    void DrawLaser(){
        int count = 0;
        laser.positionCount = laserIndices.Count;
        foreach (Vector2 pos in laserIndices)
        {
            laser.SetPosition(count,new Vector3(pos.x,pos.y,0));
            count++;
        }
    }

    public void Clear()
    {
        laser.positionCount = 0;
    }
}
