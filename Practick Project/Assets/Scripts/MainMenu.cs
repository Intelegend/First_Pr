using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
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
}
