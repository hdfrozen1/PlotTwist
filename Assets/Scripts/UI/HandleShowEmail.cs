using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Text;
using System.Collections;

public class HandleShowEmail : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField emailInput;
    public Button sendButton;
    public Text resultText;

    [Header("Formspree")]
    [SerializeField] private string formspreeEndpoint = "https://formspree.io/f/xqabydbq"; // đổi thành endpoint của bạn

    private void Start()
    {
        sendButton.onClick.AddListener(OnSendClicked);
    }

    public void OnSendClicked()
    {
        string email = emailInput.text.Trim();
        if (IsValidEmail(email))
        {
            resultText.text = "⏳ Đang gửi...";
            StartCoroutine(SendEmail(email));
        }
        else
        {
            resultText.text = "⚠️ Email không hợp lệ!";
        }
    }

    private IEnumerator SendEmail(string emailTo)
    {
        string json = "{\"email\":\"" + emailTo + "\",\"message\":\"Mật khẩu để mở cửa là: 123456\"}";
        byte[] rawBody = Encoding.UTF8.GetBytes(json);

        UnityWebRequest req = new UnityWebRequest(formspreeEndpoint, "POST");
        req.uploadHandler = new UploadHandlerRaw(rawBody);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            resultText.text = "✅ Mật khẩu đã được gửi tới email!";
        }
        else
        {
            resultText.text = "❌ Gửi mail thất bại: " + req.error;
        }
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}
