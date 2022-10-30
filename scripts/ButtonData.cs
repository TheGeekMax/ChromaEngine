using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonData : MonoBehaviour{
    public string levelName;
    public string levelCode;
    bool sandbox;
    public GameObject textObject;
    public GameObject imageObject;

    public void UpdateData(string levelName, string levelCode,LevelButtonState state){
        this.levelName = levelName;
        this.levelCode = levelCode;

        switch(state){
            case LevelButtonState.Unlocked:
                textObject.GetComponent<TextMeshProUGUI>().text = levelName;
                imageObject.GetComponent<Image>().sprite = LevelbuttonManager.instance.unlockedSprite;
                this.sandbox = false;
                break;
            case LevelButtonState.Completed:
                textObject.GetComponent<TextMeshProUGUI>().text = levelName;
                imageObject.GetComponent<Image>().sprite = LevelbuttonManager.instance.completedSprite;
                this.sandbox = false;
                break;
            case LevelButtonState.SandBox:
                textObject.GetComponent<TextMeshProUGUI>().text = levelName;
                imageObject.GetComponent<Image>().sprite = LevelbuttonManager.instance.sandBoxSprite;
                this.sandbox = true;
                break;
        }
    }

    public void Play(){
        KeepManager.instance.SetSandboxMode(sandbox);
        KeepManager.instance.Play(levelCode);
    }
}
