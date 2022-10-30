using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LevelButtonState{
    Unlocked,
    Completed,
    SandBox
}

public class LevelbuttonManager : MonoBehaviour{
    // Start is called before the first frame update
    public Sprite unlockedSprite;
    public Sprite completedSprite;
    public Sprite sandBoxSprite;

    public GameObject levelButtonPrefab;
    public GameObject parentButton;

    public static LevelbuttonManager instance;


    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start(){
        AddLevelButton("Niveau test 1","sB7FA134G5J5P-33",LevelButtonState.Unlocked);
        AddLevelButton("Niveau test 2","mEFDDFED9F0015EA6C7J7P2i-33333",LevelButtonState.Completed);
        AddLevelButton("Win 1","sFFE1520B6J8R-34",LevelButtonState.Unlocked);
        AddLevelButton("Test Ballons","lFFFFFDFF0F0FFFFF24650C6D1K6L6S6T7g-OMPNLQ333",LevelButtonState.Completed);
        AddLevelButton("Niveau hard 1","l000073F2F1F3F3848007A81F9G2NCO7QDW7Z7dBe7i7lEm-444443443",LevelButtonState.Unlocked);
        AddLevelButton("Sandbox sm","sFFFF-",LevelButtonState.SandBox);
        AddLevelButton("Sandbox me","mFFFFFFFFF-",LevelButtonState.SandBox);
        AddLevelButton("Sandbox lg","lFFFFFFFFFFFFFFFF-",LevelButtonState.SandBox);
    }

    public void AddLevelButton(string levelName, string levelCode, LevelButtonState state){
        GameObject levelButton = Instantiate(levelButtonPrefab,parentButton.transform);
        levelButton.GetComponent<ButtonData>().UpdateData(levelName, levelCode,state);
    }
}
