using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
