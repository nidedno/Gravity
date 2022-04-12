using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{
    private Animator animator;

    public static Translator instance = null;
    public bool startAnim = true;

    private bool started = false;

    public float time = 0.8f;
    void Start(){

        instance = this; 
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(startAnim)
            EndTransition();
    }

    
    public void StartTransition(){
        if(!animator) return;
        if(started) return;
        started = true;
        animator.SetTrigger("transition_start");
      
    }

    public void EndTransition(){
        if(!animator) return;
        animator.SetTrigger("transition_end");
    }


    public void Load(string scene){
        StartCoroutine(StartAnimation(scene));
    }
    
    public void Reload(){
        StartCoroutine(StartAnimation(SceneManager.GetActiveScene().name));
    }
    public string GetLevel(){
        return SceneManager.GetActiveScene().name;
    }
    public void ExitGame()
    {
        Application.Quit();
    }


    private IEnumerator StartAnimation(string scene){
        StartTransition();
        Time.timeScale = 1;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}


public enum Levels{
    level_0,
    level_1,
    level_2,
    level_3,//...
    level_4,
    level_5,
    StartMenu,
    test
}