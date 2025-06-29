using UnityEngine;

public class FlashlightCheckerBridge : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.nqdat.unity.FlashlightChecker"))
                {
                    pluginClass.CallStatic("registerTorchListener", activity);
                    Debug.Log("Đã gọi registerTorchListener thành công.");
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Lỗi khi gọi registerTorchListener: " + ex.Message);
        }
#endif
    }
}