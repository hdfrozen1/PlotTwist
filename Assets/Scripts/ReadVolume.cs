using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadVolume : MonoBehaviour
{
    DeviceInfo deviceInfo;
    public Text text;
    void Start()
    {
        deviceInfo = GetComponent<DeviceInfo>();
    }
    void Update()
    {
        if(deviceInfo != null){
            text.text = "volume :" + deviceInfo.GetVolumeLevel();
        }
    }
}
