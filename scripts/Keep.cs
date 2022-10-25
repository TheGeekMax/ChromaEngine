using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keep : MonoBehaviour
{
    string _levelCode;
    bool sandBoxMode = false;

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

    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void Play(){
        //on charge le niveau avec le code
        SceneManager.LoadScene(1);
    }
}
