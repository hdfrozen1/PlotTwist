using UnityEngine;

public class DeviceInfo : MonoBehaviour
{
    public float GetScreenBrightness()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass pluginClass = new AndroidJavaClass("com.nqdat.unity.DeviceInfoPlugin");
            return pluginClass.CallStatic<float>("getScreenBrightness", activity);
        }
    }

    public int GetVolumeLevel()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass pluginClass = new AndroidJavaClass("com.nqdat.unity.DeviceInfoPlugin");
            return pluginClass.CallStatic<int>("getVolumeLevel", activity);
        }
    }

    public bool IsCharging()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass pluginClass = new AndroidJavaClass("com.nqdat.unity.DeviceInfoPlugin");
            return pluginClass.CallStatic<bool>("isCharging", activity);
        }
    }
}
