using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keep : MonoBehaviour
{
    string _levelCode;
    int _stars;
    bool sandBoxMode = false;
    string _name = "Level Name";
    public List<string> finished_codes;
    public int starCount;

    public static Keep instance;

    public string LevelCode
    {
        get
        {
            return _levelCode;
        }
        set
        {
            _levelCode = value;
        }
    }

    public bool SandBoxMode
    {
        get
        {
            return sandBoxMode;
        }
        set
        {
            sandBoxMode = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public int Stars
    {
        get
        {
            return _stars;
        }
        set
        {
            _stars = value;
        }
    }

    void Awake(){
        if(instance == null){
            //s'execute que la première fois
            instance = this;
            SaveData saveData = SaveSystem.LoadPlayer();

            if(saveData != null){
                finished_codes = new List<string>(saveData.finished_codes);
                starCount = saveData.stars;
            }else{
                finished_codes = new List<string>();
                starCount = 0;
            }

            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void AddFinishedCode(string code){
        finished_codes.Add(code);
    }

    public void Play(){
        //on charge le niveau avec le code
        SceneManager.LoadScene(1);
    }
}
