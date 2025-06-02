using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToScale : MonoBehaviour
{
    public float zoomSpeed = 0.01f;
    public float minScale = 0.2f;
    public float maxScale = 1.5f;
    void Start()
    {
        transform.localScale = Vector3.one * minScale;
    }
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Tính khoảng cách giữa hai ngón tay ở frame trước và hiện tại
            Vector2 touch0Prev = touch0.position - touch0.deltaPosition;
            Vector2 touch1Prev = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0Prev - touch1Prev).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
        }
    }

    void Zoom(float increment)
    {
        Vector3 newScale = transform.localScale + Vector3.one * increment;
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        transform.localScale = new Vector3(newScale.x, newScale.y, 1f);
    }
}

