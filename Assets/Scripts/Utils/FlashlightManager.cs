using UnityEngine;
using UnityEngine.UI;

public class FlashlightManager : MonoBehaviour
{
    public Text text;
    // Hàm sẽ được gọi khi trạng thái đèn pin thay đổi
    public void OnFlashlightStatusChanged(string status)
    {
        text.text = "flash : " + status;
        if (status == "ON")
        {
            Debug.Log("Đèn pin đã được bật!");
            // Thực hiện hành động khi đèn pin bật
        }
        else if (status == "OFF")
        {
            Debug.Log("Đèn pin đã được tắt!");
            // Thực hiện hành động khi đèn pin tắt
        }
    }
}