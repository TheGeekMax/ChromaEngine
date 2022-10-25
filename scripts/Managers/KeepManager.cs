using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepManager : MonoBehaviour{
    [HideInInspector]
    public GameObject keepObject;

    void Start(){
        keepObject = GameObject.Find("Keep");    
    }

    public void SetSandboxMode(bool value){
        keepObject.GetComponent<Keep>().SandBoxMode = value;
    }

    public void Play(string levelCode){
        keepObject.GetComponent<Keep>().LevelCode = levelCode;
        keepObject.GetComponent<Keep>().Play();
    }

}
