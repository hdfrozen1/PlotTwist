using UnityEngine;
using UnityEngine.UI;

public class VolumeListener : MonoBehaviour
{
    [Range(0, 15)]
    public int currentVolume;
    public Text text;

    
    public void OnVolumeChanged(string value)
    {
        if (int.TryParse(value, out int volume))
        {
            currentVolume = volume;
            Debug.Log("Âm lượng hiện tại: " + volume);

            
            HandleVolumeChange(volume);
        }
    }

    private void HandleVolumeChange(int volume)
    {
        text.text = "Âm lượng hiện tại :" + currentVolume;
    }
}
