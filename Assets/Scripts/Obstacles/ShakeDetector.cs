using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public float shakeThreshold = 2;
    public float cooldown = 1;
    private float lastShakeTime;
    public GameObject[] traps;
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration.sqrMagnitude >= shakeThreshold * shakeThreshold && Time.time - lastShakeTime > cooldown)
        {
            lastShakeTime = Time.time;
            DropTraps();
        }
        
    }
    void DropTraps()
    {
        foreach (GameObject trap in traps)
        {
            Rigidbody2D rb = trap.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("rb not null");
                rb.isKinematic = false;
                rb.gravityScale = 1f;
            }
        }
    }
}
