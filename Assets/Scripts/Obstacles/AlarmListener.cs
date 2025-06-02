using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmListener : MonoBehaviour
{
    public Text text;
    public void OnAlarmRinging(string message)
    {
        text.text = "wake up";
    }
}