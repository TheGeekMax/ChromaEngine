using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMirror : Bloc{

     public override InpData UpdateInput(InpData inp){
        //on genere une couleur random
        Vector3 color = new Vector3(Random.Range(0,255), Random.Range(0,255), Random.Range(0,255));
        InpData new_inp = new InpData((inp.orientation + 1) %4, (int)color.x, (int)color.y, (int)color.z, false);
        return new_inp;
    }
}
