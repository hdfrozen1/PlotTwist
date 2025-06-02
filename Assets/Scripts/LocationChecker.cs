using System;
using UnityEngine;
using UnityEngine.UI;

public class LocationChecker : MonoBehaviour
{
    public Text text;
    public Transform location;
    public Transform locationParent;
    private bool locationEnable;
    public Transform playerPosition;
    public OpenDoorButton openDoorButton;
    void Start()
    {
        openDoorButton.teleportPlayer += TeleportPlayer;
        locationParent.gameObject.SetActive(IsLocationEnabled());
        locationEnable = IsLocationEnabled();
    }
    bool IsLocationEnabled()
    {
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaClass locationUtils = new AndroidJavaClass("com.nqdat.unity.LocationUtils"))
        {
            return locationUtils.CallStatic<bool>("isLocationEnabled");
        }
    }
    void Update()
    {
        if (IsLocationEnabled() != locationEnable)
        {
            locationEnable = IsLocationEnabled();
            locationParent.gameObject.SetActive(locationEnable);
        }
    }
    public void TeleportPlayer()
    {
        if (locationEnable)
        {
            playerPosition.position = location.position;
        }
    }
}

