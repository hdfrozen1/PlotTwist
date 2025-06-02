using UnityEngine;
using UnityEngine.UI;

public class StretchByMic : MonoBehaviour
{
    public Text text;
    public MicInput micInput; // kéo đối tượng có MicInput vào đây
    public float minVolumeThreshold = 0.1f; // Ngưỡng âm thanh nhỏ nhất để phản ứng
    public float scaleSpeed = 5f;           // Tốc độ phóng to

    private float originalScaleX;

    void Start()
    {
        originalScaleX = transform.localScale.x;
    }

    void Update()
    {
        float loudness = micInput.loudness;
        text.text = "loudness: " + loudness;

        if (loudness >= minVolumeThreshold)
        {
            float targetScaleX = originalScaleX + loudness;
            float newScaleX = Mathf.Lerp(transform.localScale.x, targetScaleX, Time.deltaTime * scaleSpeed);
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}


