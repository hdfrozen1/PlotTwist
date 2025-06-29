using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleMoveButton : BaseButton,IPointerUpHandler
{
    public bool isLeftButton;
    public bool isJumpButton;
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (isJumpButton)
        {
            TriggerButtonPressed(new object[] { "jump", true });
        }
        else if (isLeftButton)
        {
            TriggerButtonPressed(new object[] { "move", -1 });
        }
        else
        {
            TriggerButtonPressed(new object[] { "move", 1 });
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isJumpButton)
        {
            TriggerButtonPressed(new object[] { "move", 0 });
        }
    }
}
