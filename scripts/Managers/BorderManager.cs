using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour{

    public GameObject parent;
    public GameObject backgroundPrefab;

    bool[,] limitsTable;
    int gridwidth;
    SizeData sizeData;

    void Start(){
        //attendre que le grid manager soit pret

        sizeData = GetComponent<GridManager>().sizeData;
        switch (sizeData)
        {
            case SizeData.Small_4x4:
                gridwidth = 4;
                break;
            case SizeData.Medium_6x6:
                gridwidth = 6;
                break;
            case SizeData.Large_8x8:
                gridwidth = 8;
                break;
        }
           
        //def du tableau de limites
        limitsTable = new bool[gridwidth,gridwidth];
        for(int i = 0; i < gridwidth; i++){
            for(int j = 0; j < gridwidth; j++){
                limitsTable[i,j] = false;
            }
        }

        //ajout des bordures
        AddBlocToBorder(0,0);
        AddBlocToBorder(1,0);
        AddBlocToBorder(2,0);
        AddBlocToBorder(0,1);
        AddBlocToBorder(1,1);
        AddBlocToBorder(2,1);
        AddBlocToBorder(0,2);
        AddBlocToBorder(1,2);
        AddBlocToBorder(2,2);

        AddBlocToBorder(5,0);
        AddBlocToBorder(5,1);
        AddBlocToBorder(5,2);
        AddBlocToBorder(5,3);
        AddBlocToBorder(5,4);
        AddBlocToBorder(5,5);
        AddBlocToBorder(4,5);
        AddBlocToBorder(3,5);
        AddBlocToBorder(2,5);
        AddBlocToBorder(1,5);
        AddBlocToBorder(0,5);
    }

    public void AddBlocToBorder(int x, int y){
        if(limitsTable[x,y]){
            return;
        }
        //etape 2 : on ajoute le bloc aux limites
        limitsTable[x,y] = true;
        //GameObject newone = Instantiate(backgroundPrefab, new Vector3((x-gridwidth/2), (gridwidth/2)-y, 0), Quaternion.identity, parent.transform);
        //newone.transform.parent = parent.transform;
    }

    public bool IsBlocInBorder(Vector2 pos){
        return limitsTable[(int)pos.x,(int)pos.y];
    }
}
