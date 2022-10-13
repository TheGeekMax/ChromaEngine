using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{
    public List<InpData> inp_history;
    public int orientation;
    public Sprite or0;
    public Sprite or1;
    public Sprite or2;
    public Sprite or3;

    //fonction de MonoBehaviour
    void Start()
    {
        UpdateSprite();
    }


    //fonction annexes pour changer les données 
    public void RotateClockwise()
    {
        orientation = (orientation + 1) % 4;
        UpdateSprite();
    }

    public virtual void UpdateSprite(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null){
            return;
        }
        switch(orientation){
            case 0:
                spriteRenderer.sprite = or0;
                break;
            case 1:
                spriteRenderer.sprite = or1;
                break;
            case 2:
                spriteRenderer.sprite = or2;
                break;
            case 3:
                spriteRenderer.sprite = or3;
                break;
        }
    }

    public virtual InpData UpdateInput(InpData inp){
        return inp;
    }
}
