using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleMoveButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // public PlayerController playerController;
    
    public bool isLeftButton;
    public bool isJumpButton;
    

    public event Action<int> changeMoveDirection;
    public event Action<bool> changeJump;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(isJumpButton){
            // playerController.beginJump = true;
            changeJump?.Invoke(true);
        }
        else if(isLeftButton){
            changeMoveDirection?.Invoke(-1);
        }
        else if(!isLeftButton){
            changeMoveDirection?.Invoke(1);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(isJumpButton){
            return;
        }
        // playerController.moveDirection = 0;
        changeMoveDirection?.Invoke(0);
    }
}
