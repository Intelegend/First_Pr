using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public bool isFullScreen;
    void Start()
    {

    }

    void Update()
    {

    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void exitGame()
    {
        Application.Quit();
    }
    //Настройки

    public void Quality(int i)
    {
        i = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        QualitySettings.SetQualityLevel(i);

        Debug.Log(QualitySettings.GetQualityLevel().ToString());
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
   
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void BackWord()
    {
        SceneManager.LoadScene("StartScreen");
    }

   
}
