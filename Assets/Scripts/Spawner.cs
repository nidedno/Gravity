using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Action
{
    
    [Header("Объект для спавна")]
    public GameObject spawnObject;
    public Transform spawnPoint;
    [Header("Поднастройка")]
    public SpriteRenderer indicator;
    public Color readySpawn;
    public Color notReadySpawn;


    public float spawnReload;
    public bool enable = true;

    Animator animator;
    float curentReload = 0f;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        indicator.color = new Color(0,0,0,255);
        curentReload = spawnReload;
    }

    void Update()
    {
        if(curentReload <= 0f && enable)
        {   
            curentReload = spawnReload + 1f;
            animator.SetTrigger("Spawn");
            Invoke("Spawn",0.9f);

        }
        curentReload -= Time.deltaTime;
        indicator.color = Color.Lerp(indicator.color,readySpawn, (1f/spawnReload) * Time.deltaTime);
    }

    void Spawn()
    {
        Instantiate(spawnObject,spawnPoint.position,spawnPoint.rotation);
        indicator.color = notReadySpawn;
    }
    




    public override void onEnable() => enable = true;

    public override void onDisable() => enable = false;

}
