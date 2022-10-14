using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMirror : Bloc{

     public override InpData UpdateInput(InpData inp){
        InpData new_inp = new InpData(inp.orientation, (int)inp.r, (int)inp.g, (int)inp.b, false);
        //on ajoute 2 laser qui partent dans la direction de l'orientation +1 pour l'un et -1 pour l'autre
        new_inp.InitGenerator(2);
        new_inp.AddGenerated(0, new InpData((inp.orientation + 1) %4, (int)inp.r, (int)inp.g, (int)inp.b, false));
        new_inp.AddGenerated(1, new InpData((inp.orientation + 3) %4, (int)inp.r, (int)inp.g, (int)inp.b, false));
        return new_inp;
    }
}
