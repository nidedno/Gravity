using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Btn = UnityEngine.UI.Button;
public class LevelObjectController : MonoBehaviour
{
    
    public string[] scenes;
    public GameObject levelPrefab;
    public Transform parent;
    private List<string> blacklist = new List<string>(){
        "StartMenu",
        "Settings",
        "ChooseLevel",
    };
    void Start(){
        levels();

        int currentLvl = PlayerPrefs.GetInt("CurentLevel");

        foreach (var item in scenes)
        {
            if(blacklist.Contains( item ))
                continue;

            var levelobj = Instantiate(levelPrefab);
            levelobj.name = item;
            levelobj.transform.SetParent(parent);
            levelobj.transform.localScale = new Vector3(1,1,1);
            levelobj.GetComponent<LevelStatus>().lvlNumber = item.Split(' ')[1]; 
            levelobj.GetComponent<LevelStatus>().lvlToLoad = item;
            if(int.Parse(item.Split(' ')[1]) > currentLvl )
                levelobj.GetComponent<Btn>().interactable = false;
                

        }
    }

    void levels(){
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
        scenes = new string[sceneCount];
        for( int i = 0; i < sceneCount; i++ )
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
        }
    }

}
