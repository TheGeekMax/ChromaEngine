using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityButton : MonoBehaviour{
    public string name;
    public TextMeshProUGUI cityName;

    public void SetName(string name){
        this.name = name;
        cityName.text = name;
    }

    public void Play(){
        LevelbuttonManager.instance.CityOnClick(name);
    }
}
