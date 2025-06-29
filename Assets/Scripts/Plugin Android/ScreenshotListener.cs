using UnityEngine;
using UnityEngine.UI;

public class ScreenshotListener : MonoBehaviour
{
    public Text text;
    void Awake()
    {
        // Gọi plugin để bắt đầu theo dõi
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass plugin = new AndroidJavaClass("com.nqdat.unity.ScreenshotDetector"))
        {
            using (AndroidJavaObject activity = GetActivity())
            {
                plugin.CallStatic("startDetecting", activity);
            }
        }
#endif
    }

    public void OnScreenshotTaken()
    {
        text.text = "take screenshot";
        Debug.Log("Screenshot taken! You can handle logic here.");
        // Thực hiện hành động mong muốn
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaObject GetActivity()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
#endif
}
