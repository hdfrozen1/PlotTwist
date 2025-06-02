using UnityEngine;

public class FloatingInputReceiver : MonoBehaviour
{
    public void StartFloating()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.ngdat.unity.FloatingPlugin"))
        {
            pluginClass.CallStatic("startFloating", context);
        }
    }
}

