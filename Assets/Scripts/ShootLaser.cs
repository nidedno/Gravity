using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : Action
{
    public Material mat;
    public Transform shootPoint;
    public GameObject laserEffect;
    public GameObject shootEffect;
    public bool enable;
    Laser laser;
    string beamName;
    void Start(){
        beamName = gameObject.name + " beam";
    }
    void Update()
    {
        if(enable){
            Destroy(GameObject.Find(beamName));
            laser = new Laser(shootPoint.position,transform.right,laserEffect,mat,beamName);
        }
    }

    public override void onEnable()
    {
        enable = true;
        laserEffect.SetActive(true);
        shootEffect.SetActive(true);
    }
     
    public override void onDisable()
    {
        laser.Clear();
        enable = false;
        laserEffect.SetActive(false);
        shootEffect.SetActive(false);
        
    }

}
