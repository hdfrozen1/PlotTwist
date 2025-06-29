using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WakeUpPlayer : BaseButton
{
    public Text expYear;
    public LoopingScrollSelector[] loopingScrolls = new LoopingScrollSelector[2];
    string clock;
    string currentTime;
    public override void OnPointerDown(PointerEventData eventData)
    {
        clock = GetCurrentHourInScrollClock();

        currentTime = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
        if (gameObject.name == "Player" && (clock == currentTime))
        {
            gameObject.GetComponent<PlayerController>().enabled = true;
        }
    }

    void Start()
    {
        if (expYear == null)
        {
            return;
        }
        expYear.text = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
    }
    private string GetCurrentHourInScrollClock()
    {
        string clock = "";
        foreach (LoopingScrollSelector timeComponent in loopingScrolls)
        {
            clock += timeComponent.GetSelectedValue();
            if (timeComponent.scrollType == ScrollType.Hour)
            {
                clock += ":";
            }
        }
        return clock;
    }

}
