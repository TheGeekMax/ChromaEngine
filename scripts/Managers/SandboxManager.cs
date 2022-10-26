using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandboxManager : MonoBehaviour
{
    public bool sandboxMode = false;
    public int toolId = 0;
    // 0 - add blocs
    // 1 - remove blocs
    // 2 - add/remove borders

    public GameObject tools;

    [Header("buttons sprites")]
    public Sprite addBlocSprite;
    public Sprite removeBlocSprite;
    public Sprite addBorderSprite;

    public GameObject toolButton;

    public GameObject addPanel;

    public GameObject label;

    int currentId = 0;

    public static SandboxManager instance;

    void Awake(){
        instance = this;
    }

    void Start(){
        UpdateId(0);
    }

    public void UpdateSandboxMod(){
        Debug.Log("UpdateSandboxMod");
        if(sandboxMode){
            tools.SetActive(true);
        }else{
            tools.SetActive(false);
        }
    }

    
    void UpdateSprite(){
        Debug.Log("UpdateSprite");
        if(toolId == 0){
            toolButton.GetComponent<Image>().sprite = addBlocSprite;
            addPanel.SetActive(true);
        }else if(toolId == 1){
            toolButton.GetComponent<Image>().sprite = removeBlocSprite;
            addPanel.SetActive(false);
        }else if(toolId == 2){
            toolButton.GetComponent<Image>().sprite = addBorderSprite;
            addPanel.SetActive(false);
        }
    }

    public void UpdateTool(){
        toolId = (toolId+1)%3;
        UpdateSprite();
    }

    public void UpdateId(int id){
        if(currentId+id >= 0 && currentId+id < GetComponent<BlocManager>().GetLength()){
            currentId += id;
            label.GetComponent<TextMeshProUGUI>().text = GetComponent<BlocManager>().FindBlocDataWithId(currentId).name;
        }
    }

    public void PlaceBlock(){
        //on place le block
        GetComponent<GridManager>().AddBlocToNearest(GetComponent<BlocManager>().FindBlocDataWithId(currentId).name);
    }
}
