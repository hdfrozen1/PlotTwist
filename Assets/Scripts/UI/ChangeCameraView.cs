using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{
    public Vector3 newLocation;
    public Vector3 newRotation;
    public Camera mainCamera;
    public bool is3D = false;
    public BoxCollider2D door;
    void Start()
    {
        mainCamera = Camera.main;
        transform.position = new Vector3(0, 0, -10);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        mainCamera.orthographic = true;
        door = GameObject.Find("Door").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchCamera();
        }
    }
    private void SwitchCamera()
    {
        door.enabled = is3D;
        is3D = !is3D;

        if (is3D)
        {
            mainCamera.orthographic = false;
            transform.position = newLocation;
            transform.localRotation = Quaternion.Euler(newRotation.x, newRotation.y, newRotation.z);

        }
        else
        {
            mainCamera.orthographic = true;
            transform.position = new Vector3(0, 0, -10);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
