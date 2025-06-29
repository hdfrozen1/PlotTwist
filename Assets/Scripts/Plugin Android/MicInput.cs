using UnityEngine;

public class MicInput : MonoBehaviour
{
    public float loudness;
    public float sensitivity = 100f;

    private AudioClip micClip;
    private const int sampleSize = 256;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micClip = Microphone.Start(null, true, 10, 44100);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy micro");
        }
    }

    void Update()
    {
        loudness = GetLoudnessFromMic() * sensitivity;
    }

    float GetLoudnessFromMic()
    {
        if (micClip == null || !Microphone.IsRecording(null)) return 0f;

        float[] data = new float[sampleSize];

        int micPosition = Microphone.GetPosition(null) - sampleSize;
        if (micPosition < 0) return 0f;

        micClip.GetData(data, micPosition);

        float sum = 0f;
        foreach (float s in data)
        {
            sum += Mathf.Abs(s);
        }

        return sum / sampleSize;
    }
}
