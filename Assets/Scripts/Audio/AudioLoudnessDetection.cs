using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    public float loudness;
    void Start()
    {
        MicrophoneToAudioClip();
    }


    void Update()
    {
        loudness = GetLoudnessFromMicrophone();
    }
    public void MicrophoneToAudioClip()
    {
        //get the first microphone in device list
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName,true,20,AudioSettings.outputSampleRate);
    }
    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPostion, AudioClip clip)
    {
        int startPosition = clipPostion - sampleWindow;
        if (startPosition < 0)
        {
            return 0;
        }
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute loundness
        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
