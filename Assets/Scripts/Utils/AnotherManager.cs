using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class AnotherManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    void Start()
    {
        levelLoader = GameObject.FindObjectOfType<LevelLoader>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (transform.position.x <= collision.transform.position.x)
            {
                if (levelLoader != null)
                {
                    levelLoader.LoadNextLevel();
                }
            }
        }
    }

}
