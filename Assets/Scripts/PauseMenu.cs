using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Animator pauseAnimator;
    public UIcontroller ui;
    public Image btnImage;
    public Sprite on;
    public Sprite off;
    private bool pause = false;

    public void click(){
        pause = !pause;
        if(pause){
            Pause();
            btnImage.sprite = off; 
        }else{
            Unpause();
            btnImage.sprite = on; 
        }
    }

    public void Pause(){
        ui.pause = true;
        Time.timeScale = 0;
        pauseAnimator.SetTrigger("pause");
    }
    public void Unpause(){
        ui.pause = false;
        Time.timeScale = 1;
        pauseAnimator.SetTrigger("unpause");
    }

    public void Restart(){
        Translator.instance.Reload();
    }

    public void Exit(){
        Translator.instance.Load(Levels.StartMenu.ToString());
    }

}
