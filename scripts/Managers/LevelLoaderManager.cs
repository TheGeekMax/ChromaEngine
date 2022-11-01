using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//pour charger un json
using System.IO;

public class LevelLoaderManager : MonoBehaviour
{
    //instance
    public static LevelLoaderManager instance;

    //ficier json a mettre dans l'editor
    public TextAsset levelData;


    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void LoadData(){
        //etape 1 : charger les données (dans le dossier parent le Levels.json)
        string jsonString = levelData.text;
        
        //etape 2 : charger les données
        LevelParser levelParser = JsonUtility.FromJson<LevelParser>(jsonString);

        //etape 3 : charger les boutons des villes
        //3.1 : ajouter les villes
        foreach(string city in levelParser.cities){
            LevelbuttonManager.instance.AddCity(city);
        }
        //3.2 : ajouter les niveaux
        foreach(LevelInfos level in levelParser.levels){
            if(level.sandbox){
                LevelbuttonManager.instance.AddLevelSandBox(level.name,levelParser.cities[level.city],level.levelCode);
            }
            else{
                if(level.completed){
                    LevelbuttonManager.instance.AddLevelCompleted(level.name,levelParser.cities[level.city],level.levelCode);
                }
                else{
                    LevelbuttonManager.instance.AddLevelUnlocked(level.name,levelParser.cities[level.city],level.levelCode);
                }
            }
        }

        //etape 4 : afficher les villes
        LevelbuttonManager.instance.ShowCities();
    }

}
 