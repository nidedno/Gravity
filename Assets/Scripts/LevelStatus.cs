
using UnityEngine;
using UnityEngine.UI;
using Btn = UnityEngine.UI.Button;
public class LevelStatus : MonoBehaviour
{
    public string lvlNumber;
    public string lvlToLoad = "level 0";
    public bool Complete = false;

    public Text levelName;
    public Sprite imageX;
    public Sprite imageO;
    public Image[] levelStars;
    private Btn btn;
    void Awake()
    {
        btn = GetComponent<Btn>();
    }
    void Start()
    {
        levelName.text = lvlNumber;
        btn.onClick.AddListener(LoadLevel);

        
        if(btn.interactable)
        {
            int i = 1;
            foreach (Image item in levelStars)
            {
                item.gameObject.SetActive(true);
               // Debug.Log(PlayerPrefs.GetInt("lvl_" + lvlNumber + "_" + i));
                if(PlayerPrefs.GetInt("lvl_" + lvlNumber + "_" + i) == 1)
                {
                    item.sprite = imageX;
                }
                else
                {
                    item.sprite = imageO;
                }
                i++;
            }
        }




    }

    private void LoadLevel()
    {
        Translator.instance.Load(lvlToLoad);
    }
}
