using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocManager : MonoBehaviour
{
    public List<BlocData> blocs;

    public GameObject FindBloc(string name){
        foreach(BlocData bloc in blocs){
            if(bloc.name == name){
                return bloc.prefab;
            }
        }
        return null;
    }
}
