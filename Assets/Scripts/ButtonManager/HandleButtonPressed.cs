using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class HandleButtonPressed : BaseButton
{
    public TextMeshProUGUI MailInput;
    private string userMail;
    public override void OnPointerDown(PointerEventData eventData)
    {
        userMail = MailInput.text;
        if (IsValid(userMail))
        {
            userMail = Clean(userMail);
            Debug.Log("is valid mail: " + userMail);
            TriggerButtonPressed(new object[] { userMail });
        }
        else
        {
            Debug.Log("not a valid email");
        }

        
    }
    public string Clean(string email)
    {
        if (string.IsNullOrEmpty(email))
            return "";

        email = email.Trim();

        // Loại bỏ các ký tự không hiển thị hoặc không in được (như U+200B, U+00A0, ...)
        email = new string(email.Where(c => !char.IsControl(c) && !char.IsWhiteSpace(c) && c <= 127).ToArray());

        return email;
    }

    public bool IsValid(string email)
{
    email = email.Trim();
    try
    {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}
}
