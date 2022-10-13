using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InpData{
    public int orientation;
    public int r,g,b;
    public bool show;

    public InpData(int orientation, int r, int g, int b, bool show){
        this.orientation = orientation;
        this.r = r;
        this.g = g;
        this.b = b;
        this.show = show;
    }

    // cas ou osef
    public InpData(int orientation, int r, int g, int b){
        this.orientation = orientation;
        this.r = r;
        this.g = g;
        this.b = b;
        this.show = false;
    }

    public int getOrientation(){
        return orientation;
    }

    public Vector3 getColor(){
        return new Vector3(r,g,b);
    }

    public bool IsShown(){
        return show;
    }
}
