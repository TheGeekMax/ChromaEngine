using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorData{
    public Vector2 position;
    public int orientation;
    public Vector3 color;
    public int lifespan;

    public GeneratorData(Vector2 position, int orientation, Vector3 color){
        this.position = position;
        this.orientation = orientation;
        this.color = color;
        this.lifespan = 50;
    }

    public InpData ToInpData(){
        return new InpData(orientation, (int)color.x, (int)color.y, (int)color.z);
    }
}
