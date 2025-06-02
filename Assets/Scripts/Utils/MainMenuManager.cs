using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OpenSetting()
    {
        SceneManager.LoadScene("Setting Scene");
    }
    public void OpenLevelsMenu()
    {
        SceneManager.LoadScene("Levels Menu");
    }
    
}
