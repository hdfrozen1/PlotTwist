using UnityEngine;

public class FloatingLevelLauncher : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaObject activity;
    private AndroidJavaClass pluginClass;
#endif

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        pluginClass = new AndroidJavaClass("com.nqdat.unity.PluginHelper");

        // Yêu cầu quyền overlay
        pluginClass.CallStatic("requestOverlayPermission", activity);
        LaunchFloatingLevel();
#endif
    }

    public void LaunchFloatingLevel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        pluginClass.CallStatic("startMiniGame", activity);
        activity.Call("moveTaskToBack", true); // Đưa Unity về nền
#endif
    }

    public void StopFloatingLevel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        pluginClass.CallStatic("stopMiniGame", activity);
#endif
    }
}
