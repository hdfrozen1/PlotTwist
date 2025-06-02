using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExpireDateController : MonoBehaviour,IPointerDownHandler
{
    public Text expYear;
    public LoopingScroll loopingScroll;
    public MinuteLoopingScroll minuteLoopingScroll;
    string clock;
    string currentTime;
    public void OnPointerDown(PointerEventData eventData)
    {
        clock = loopingScroll.GetSelectedHour() + ":" + minuteLoopingScroll.GetSelectedMInute();
        currentTime=System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
        if(gameObject.name == "Player" && (clock == currentTime)){
            gameObject.GetComponent<PlayerController>().enabled = true;
        }
    }

    void Start()
    {
        if(expYear == null){
            return;
        }
        expYear.text = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
    }

}
