// using UnityEngine;

// public class FloatingWidgetController : MonoBehaviour
// {
//     public void StartFloatingWidget()
//     {
// #if UNITY_ANDROID && !UNITY_EDITOR
//         AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//         AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

//         AndroidJavaClass plugin = new AndroidJavaClass("com.nqdat.unity.PluginHelper");
//         plugin.CallStatic("startFloating", activity);
// #endif
//     }

//     public void StopFloatingWidget()
//     {
// #if UNITY_ANDROID && !UNITY_EDITOR
//         AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//         AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

//         AndroidJavaClass plugin = new AndroidJavaClass("com.nqdat.unity.PluginHelper");
//         plugin.CallStatic("stopFloating", activity);
// #endif
//     }
// }
using UnityEngine;

public class FloatingWidgetController : MonoBehaviour
{
    public void StartFloatingLevel()
{
#if UNITY_ANDROID && !UNITY_EDITOR
    AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

    AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");
    AndroidJavaClass pluginHelper = new AndroidJavaClass("com.nqdat.unity.PluginHelper");
    pluginHelper.CallStatic("startFloatingGameService", context);
#endif
}
}
