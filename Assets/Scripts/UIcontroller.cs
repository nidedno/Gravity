using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{

    public string minutes,seconds;
    public bool pause = false;
    private float timer;
    public TMPro.TextMeshProUGUI time;
    public TMPro.TextMeshProUGUI level;
    public TMPro.TextMeshProUGUI ded;
    public static UIcontroller instance;

    void Awake()
    {
        instance = this;
    }


    void Start(){


        level.text = SceneManager.GetActiveScene().name;
        time.text = "00 m 00 s";
        ded.text = "deaths: " + PlayerPrefs.GetInt(level.text + " ded");
        
    }
    // Update is called once per frame
    void Update()
    { 
        if(pause) return;

        timer += Time.deltaTime;
        minutes = Mathf.Floor(timer / 60).ToString("0");
        seconds = (timer % 60).ToString("00");

        time.text = string.Format("{0} m {1} s", minutes, seconds);
    }


}
