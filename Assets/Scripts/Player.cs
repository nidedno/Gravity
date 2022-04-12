using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    [Range(.1f,1f)]
    public float minInput = 0.5f;
    public SpriteRenderer gravitySprite;
    public SpriteRenderer spinerSprite;
    public GameObject dieEffect;

    private Animator animator;
    private float moveX,moveY;
    private Rigidbody2D body;

    private bool locked = false; // для блокировки смены гравитации

    public static Player LocalPlayer; // сам игрок

   
    private Vector3 start;
    public bool point {get; private set;} // переменная для подобранной монетки;

    public bool alive = true; // состояние игрока

    void Start()
    {
      body = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      start = transform.position;
      LocalPlayer = this;
    }

   
    void Update()
    {
        GetInput();

        if(Input.GetKeyDown(KeyCode.Space) && !locked && alive)
            SwitchGravity();
    }

    void FixedUpdate(){
        Move();

    }
    void GetInput(){
      //  moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal"); // получение нажатых клавиш
    }

    void Move(){
        if(!alive) return;
        
        Vector2 moveVector = new Vector2( moveX, 0);

        if(Mathf.Abs(moveX) != 0)
        {
           moveVector.x =  Mathf.Sign(moveX) * Mathf.Clamp(Mathf.Abs(moveX),minInput,1); // получаем скорость
        }
        
        ///if(Mathf.Abs(moveVector.magnitude) > 1){
        //    moveVector = new Vector2(Mathf.Sign(moveX)*(1/Mathf.Sqrt(2)),Mathf.Sign(moveY)*(1/Mathf.Sqrt(2)));
      //  }

       // animator.SetFloat("Walk",moveVector.magnitude);
        

        body.velocity = moveVector*speed; 
        spinerSprite.transform.Rotate(0, 0, -moveVector.x*speed, Space.Self);
       
    }
    // возвращает направление гравитации
    public bool GetGravity(){
        return Mathf.Sign(body.gravityScale) > 0;
    }

    // изменяет направление вектора гравитации
    void SwitchGravityVector(){
        string triggerName = GetGravity() ? "down" : "up";
        animator.SetTrigger(triggerName);
    }
    // изменяет напраавление гравитации
    public void SwitchGravity(){
        body.gravityScale = -body.gravityScale;
        SwitchGravityVector();

        // звук смены
        AudioManager.instance.Play("PlayerSwitch");
    }

    public void Die(){
        if(alive){
            alive = false;
            body.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("Die");
            string lvlname = Translator.instance.GetLevel() + " ded";
            PlayerPrefs.SetInt(lvlname,PlayerPrefs.GetInt(lvlname) + 1);
        }
    }

    private void realDie()
    {
        AudioManager.instance.Play("PlayerDie");
        GameObject effect = Instantiate(dieEffect,transform.position,transform.rotation);
        Destroy(effect,4f);
        Translator.instance.Reload();


    }

    public void BlockGravity(bool status){
        locked = status;
    }
    // ставим подобрана ли очко
    public void SetPoint() => point = true;


}
