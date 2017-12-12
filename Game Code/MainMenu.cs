using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";
    public string mainMenu = "MainMenu";
    public string howToPlay = "HowTo";
    public SceneAnimation sceneAnimation;
    public Text resetText;

    public void Play()
    {
        sceneAnimation.FadeTo(levelToLoad);
    }

    public void QuitGame()  
    {
        Application.Quit();
    }

    public void ResetStats(string resetString)
    {
        try
        {
            PlayerPrefs.DeleteKey("PLIFE");
            PlayerPrefs.DeleteKey("PMONEY");
            PlayerPrefs.DeleteKey("PLEVEL");
        }
        catch (Exception e) { Debug.Log(e); }
        finally { resetText.text = "DONE"; }
    }

    public void TutorialPage()
    {
        sceneAnimation.FadeTo(howToPlay);
    }
}
