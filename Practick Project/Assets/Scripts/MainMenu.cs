using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int window;


    // Use this for initialization
    void Start()
    {
        window = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void startGame()
    {
        SceneManager.LoadScene("Practik");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    //Настройки
    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void BackWord()
    {
        SceneManager.LoadScene("Gui");
    }

}
