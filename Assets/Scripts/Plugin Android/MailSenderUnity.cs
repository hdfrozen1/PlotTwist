
using UnityEngine;

public class MailSenderUnity : MonoBehaviour
{
    public HandleButtonPressed handleButtonPressed;
    void Start()
    {
        handleButtonPressed.RegisterListener(SendMailFromUnity);
    }
    public void SendMailFromUnity(object[] email)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass mailSender = new AndroidJavaClass("com.nqdat.unity.MailSender"))
        {
            mailSender.CallStatic("sendMail",email[0]);
        }
#endif

    }

}
