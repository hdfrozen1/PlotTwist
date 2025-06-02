using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int currentLevel = 1;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadNextLevel()
    {
        currentLevel += 1;
        SceneManager.LoadScene("Level" + currentLevel);
    }
}
