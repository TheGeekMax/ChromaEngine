using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 color;

    public void SetColor(int r, int g, int b){
        this.color = new Vector3(r,g,b);
        UpdateSprite();
    }

    void UpdateSprite(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null){
            return;
        }
        spriteRenderer.color = new Color(color.x/255f, color.y/255f, color.z/255f,.7f);
    }
}
