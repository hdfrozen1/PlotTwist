using UnityEngine;
using UnityEngine.UI;
public class BrightnessListener : MonoBehaviour
{
    public Text text;
    public Image image;
    void Start()
    {
        
    }
    public void OnBrightnessChanged(string value)
    {
        int brightness = int.Parse(value);
        Debug.Log("Brightness: " + brightness);
        HandleBrightnessChange(brightness);
    }
    private void HandleBrightnessChange(int brightness)
    {
        text.text = "do sang hien tai : " + brightness;
        image.color = new Color(image.color.r,image.color.g,image.color.b,255 - brightness);
    }

}
