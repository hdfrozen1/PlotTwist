using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinePart : MonoBehaviour
{
    public GameObject player;
    int children;
    public int currentChild = 0;
    private void Start()
    {
        children = transform.childCount;
        Debug.Log("children : " + children);
    }
    void Update()
    {
        if (currentChild == children)
        {
            player.transform.position = transform.position;
            player.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
