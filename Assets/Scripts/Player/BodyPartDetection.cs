using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartDetection : MonoBehaviour
{
    public CombinePart combinePart;
    void Start()
    {
        combinePart = GetComponentInParent<CombinePart>();
    }
    void OnDisable()
    {
        combinePart.currentChild += 1;
    }
}
