using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : Action
{
    public bool on = true;
    public Sprite finishOn;
    public Sprite finishOff;
    public Levels nextLevel;
    public int CurentLevel;
    

    private SpriteRenderer spriteRenderer;
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = on ? finishOn : finishOff;
        
    }

    void Start()
    {
      //  setLvLStars();
    }

    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.CompareTag("Player") && on){
            Player.LocalPlayer.alive = false;
            Player.LocalPlayer.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;;
        

            if(CurentLevel >= PlayerPrefs.GetInt("CurentLevel"))
                PlayerPrefs.SetInt("CurentLevel",CurentLevel + 1);

            setLvLStars();


            Translator.instance.Load(nextLevel.ToString().Replace("_", " "));
        }
    }

    public override void onEnable(){
        on = true;
        spriteRenderer.sprite = finishOn;
    }

    public override void onDisable(){
        on = false;
        spriteRenderer.sprite = finishOff;
    }
    
    private void setLvLStars()
    {
        string lvl = "lvl_" + CurentLevel;

        
        // level awards
        PlayerPrefs.SetInt(lvl + "_1",1);

        //star 2
        PlayerPrefs.SetInt(lvl + "_2", Player.LocalPlayer.point ? 1:0);

        // star 3
        int time = int.Parse(UIcontroller.instance.minutes);

        if(time < 1)
            
            PlayerPrefs.SetInt(lvl + "_3", 1);
        else
        {
            PlayerPrefs.SetInt(lvl + "_3", 0);
        }
    }




}
