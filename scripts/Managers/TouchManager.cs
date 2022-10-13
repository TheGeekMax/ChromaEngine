using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    int gridWidth;

    Vector2Int beginTouchPosition;
    Vector2 beginTouchPositionFloat;
    int type; //0 = hold, 1 = move
    GameObject choosenBloc;
    bool dontMove;

    void Start(){
        gridWidth = GetComponent<GridManager>().gridWidth;
    }

    // programme de detection de toucches
    void Update(){
        if(Input.touchCount > 0){
            //données annexes
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            float x = Mathf.Ceil(touchPos.x)+(gridWidth/2)-1;
            float y = (gridWidth/2)-Mathf.Ceil(touchPos.y);
            Vector2 intTouchPos = new Vector2(Mathf.Clamp(x,0,gridWidth-1),Mathf.Clamp(y,0,gridWidth-1));



            Debug.Log(touchPos);

            if(touch.phase == TouchPhase.Began){
                //debut
                beginTouchPosition = new Vector2Int((int)intTouchPos.x,(int)intTouchPos.y);
                beginTouchPositionFloat = touchPos;
                type = 0;
                choosenBloc = GetComponent<GridManager>().GetBlocObject((int)intTouchPos.x,(int)intTouchPos.y);
                dontMove = true;
                if(GetComponent<BorderManager>().IsBlocInBorder(intTouchPos)){
                    dontMove = false;
                }
            }else if(touch.phase == TouchPhase.Moved){
                //milieu
                if((Vector2.Distance(beginTouchPositionFloat,touchPos) > 0.3f || type == 1) && !dontMove){
                    //on detecte un mouvement
                    if(type == 0 && choosenBloc != null){
                        type = 1;
                        GetComponent<GridManager>().RemoveBlocId((int)beginTouchPosition.x,(int)beginTouchPosition.y);
                        choosenBloc.transform.position = new Vector3(touchPos.x-.5f, touchPos.y+.5f, 0);
                    }else if (type == 1){
                        choosenBloc.transform.position = new Vector3(touchPos.x-.5f, touchPos.y+.5f, 0);
                    }
                }
            }else if(touch.phase == TouchPhase.Ended ){
                //cas du release
                int clampedX  = (int)Mathf.Clamp(intTouchPos.x,0,gridWidth-1);
                int clampedY  = (int)Mathf.Clamp(intTouchPos.y,0,gridWidth-1);
                if(type == 0){
                    GetComponent<GridManager>().RotateBloc(clampedX, clampedY);
                }else if(!dontMove){
                    if(GetComponent<GridManager>().GetBlocObject(clampedX,clampedY) == null && GetComponent<BorderManager>().IsBlocInBorder(new Vector2(clampedX,clampedY))){
                        GetComponent<GridManager>().SetBlocId(clampedX, clampedY,choosenBloc);
                        choosenBloc.transform.position = new Vector3(Mathf.Ceil(Mathf.Clamp(touchPos.x,-gridWidth/2+1,gridWidth/2))-1, Mathf.Ceil(Mathf.Clamp(touchPos.y,-gridWidth/2+1,gridWidth/2)), 0);
                    }else{
                        GetComponent<GridManager>().SetBlocId((int)beginTouchPosition.x, (int)beginTouchPosition.y,choosenBloc);
                        choosenBloc.transform.position = new Vector3(beginTouchPosition.x-(gridWidth/2), (gridWidth/2)-beginTouchPosition.y, 0);
                    }
                }
            }
        }
    }
}
