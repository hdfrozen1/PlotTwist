using UnityEngine;
using UnityEngine.UI;

public class DeviceBridge : MonoBehaviour
{
    public Text text;
    void Awake()
    {
        //Debug.Log("Hello from Device Bridge");
#if UNITY_ANDROID && !UNITY_EDITOR
        try
    {
        text.text = "trying call initialize ";
        using (AndroidJavaClass bridge = new AndroidJavaClass("com.nqdat.unity.BridgeUnity"))
        {
            text.text = "calling UnityBridge Initialize ";
            if(bridge == null){
                text.text = "is null";
            }else{
                text.text = "not null";
            }
            bridge.CallStatic("Initialize");
        }
    }
    catch (System.Exception ex)
    {
        text.text = "Cant call initialize ";
    }
#endif
    }
}
