using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader {
  
    public enum Scenes{
        StartMenu,
        level_1,
        test,
    }

    public static void Load(Scenes scene){
        Translator.instance.StartTransition();
        SceneManager.LoadScene(Scenes.StartMenu.ToString());
    }

    public static void ReloadScene(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public static void LoadNext(){
        SceneManager.LoadScene(Scenes.StartMenu.ToString());
    }

}


