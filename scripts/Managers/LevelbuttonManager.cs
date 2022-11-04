using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelbuttonManager : MonoBehaviour{
    // Start is called before the first frame update
    public Sprite unlockedSprite;
    public Sprite completedSprite;
    public Sprite sandBoxSprite;

    public GameObject levelButtonPrefab;
    public GameObject cityButtonPrefab;
    public GameObject parentButton;

    [Header("buttons")]
    public GameObject backButton;

    public static LevelbuttonManager instance;

    public enum LevelButtonState{
        Unlocked,
        Completed,
        SandBox
    }

    List<string> Cities;
    Dictionary<string, LevelData> levelDataDict;


    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

        levelDataDict = new Dictionary<string, LevelData>();
        Cities = new List<string>();
    }

    void Start(){
        LevelLoaderManager.instance.LoadData();
        /*
        //add cities
        AddCity("Tutorial City");
        AddCity("Test City");
        AddCity("SandBox City");

        //add levels
        AddLevelUnlocked("Niveau test 1","Test City","sB7FA134G5J5P-33");
        AddLevelCompleted("Niveau test 2","Test City","mEFDDFED9F0015EA6C7J7P2i-33333");
        AddLevelUnlocked("Win 1","Test City","sFFE1520B6J8R-34");
        AddLevelCompleted("Test Ballons","Test City","lFFFFFDFF0F0FFFFF24650C6D1K6L6S6T7g-OMPNLQ333");
        AddLevelUnlocked("Niveau hard 1","Test City","l000073F2F1F3F3848007A81F9G2NCO7QDW7Z7dBe7i7lEm-444443443");
        AddLevelSandBox("Sandbox sm","SandBox City","sFFFF-");
        AddLevelSandBox("Sandbox me","SandBox City","mFFFFFFFFF-");
        AddLevelSandBox("Sandbox lg","SandBox City","lFFFFFFFFFFFFFFFF-");

        ShowCities();
        */
    }

    // Onclick functions
    public void CityOnClick(string cityName){
        Debug.Log("CityOnClick: " + cityName);
        ShowLevels(cityName);
    }

    public void Back(){
        ShowCities();
    }

    //fonctions d'affichages boutons 
    void ResetButtons(){
        foreach(Transform child in parentButton.transform){
            Destroy(child.gameObject);
        }
    }

    public void ShowCities(){
        ResetButtons();
        backButton.SetActive(false);
        foreach(string cityName in Cities){
            GameObject cityButton = Instantiate(cityButtonPrefab, parentButton.transform);
            cityButton.GetComponent<CityButton>().SetName(cityName);
        }
    }

    void ShowLevels(string cityName){
        ResetButtons();
        backButton.SetActive(true);
        foreach(KeyValuePair<string, LevelData> levelData in levelDataDict){
            //Debug.Log(levelData.Key + " " + levelData.Value.cityName);
            if(levelData.Value.cityName == cityName){
                GameObject levelButton = Instantiate(levelButtonPrefab, parentButton.transform);
                levelButton.GetComponent<ButtonData>().UpdateData(levelData.Value.levelName, levelData.Value.levelCode, levelData.Value.stars,levelData.Value.state);
            }
        }
    }


    //fonction d'ajout backend

    public void AddCity(string cityName){
        if(!Cities.Contains(cityName)){
            Cities.Add(cityName);
        }
    }

    public void AddLevelUnlocked(string levelName, string city, string levelCode, int stars = 0){
        if(!levelDataDict.ContainsKey(levelName)){
            levelDataDict.Add(levelName, LevelData.DefaultLevel(levelName, city,levelCode, stars));
        }
    }

    public void AddLevelCompleted(string levelName, string city,string levelCode, int stars = 0){
        if(!levelDataDict.ContainsKey(levelName)){
            levelDataDict.Add(levelName, LevelData.DefaultCompleted(levelName, city, levelCode,stars));
        }
    }

    public void AddLevelSandBox(string levelName, string city, string levelCode, int stars = 0){
        if(!levelDataDict.ContainsKey(levelName)){
            levelDataDict.Add(levelName, LevelData.DefaultSandBox(levelName, city, levelCode,stars));
        }
    }
}
