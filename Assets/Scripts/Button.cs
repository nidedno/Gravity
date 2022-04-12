using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [Header("Действия кнопки")]
    public Action[] actions;

    [Header("Настройки кнопки")]
    public Sprite buttonOn;
    public Sprite buttonOff;


    public Text buttonText;

    public Color colorOn;
    public Color colorOff;

    private string textOn = "ON";
    private string textOff = "OFF";

    public bool on;
    public bool once;

    private UnityAction buttonEnable;
    private UnityAction buttonDisable;
    private SpriteRenderer spriteRenderer;


    
 
    void Start(){

        foreach (Action action in actions)
        {
            buttonEnable += action.onEnable;
            buttonDisable += action.onDisable;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = on ? buttonOn : buttonOff;
        buttonText.text =  on ? textOn : textOff;
        buttonText.color = on ? colorOn : colorOff;

        use();
    }

    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.CompareTag("Player")){
            Switch();
        }
    }
    
    
    void Switch(){
        if(!on == false && once == true)
            return;

        on = !on;
        spriteRenderer.sprite = on ? buttonOn : buttonOff;
        buttonText.text =  on ? textOn : textOff;
        buttonText.color = on ? colorOn : colorOff;

        use();
    }

    private void use(){
        
        if(on == true){
            buttonEnable();
        }else{
            buttonDisable();
        }
    }
    


   

}
