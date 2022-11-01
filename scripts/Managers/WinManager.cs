using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour{

    [HideInInspector]
    public bool win = false;

    public void Win(){
        win = true;
        UpdateData();
    }

    void UpdateData(){
        if(win && !GetComponent<SandboxManager>().sandboxMode){
            GuiManager.instance.Open("win");
        }
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
