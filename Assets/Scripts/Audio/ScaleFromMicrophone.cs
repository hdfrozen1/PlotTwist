using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioLoudnessDetection audioLoudnessDetection;
    //public float maxScaleX;
    public Vector3 maxScale;
    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    public float scaleSpeed = 5f;
    float loudness;
    
    void Update()
    {
        loudness = audioLoudnessDetection.loudness * loudnessSensibility;
        Debug.Log("loudness :" + loudness);
        if (loudness < threshold)
        {
            loudness = 0;
            return;
        }
        
        transform.localScale = Vector3.Lerp(transform.localScale, maxScale, scaleSpeed * Time.deltaTime);
    }
}
