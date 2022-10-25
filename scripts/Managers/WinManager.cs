using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour{

    public GameObject winPanel;
    [HideInInspector]
    public bool win = false;

    public void Win(){
        win = true;
        UpdateData();
    }

    void UpdateData(){
        if(win && !GetComponent<SandboxManager>().sandboxMode){
            winPanel.SetActive(true);
        }
    }

    void Awake(){
        winPanel.SetActive(false);
    }

    public void IsWin(){
        if(GetComponent<GridManager>().IsWin()){
            Win();
        }
    }

    public void Home(){
        //on reset keep
        GameObject.Find("Keep").GetComponent<Keep>().SandBoxMode = false;
        GameObject.Find("Keep").GetComponent<Keep>().LevelCode = "";
        SceneManager.LoadScene(0);
    }

}
