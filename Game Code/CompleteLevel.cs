using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int nextLevelIndex = 2;
    public SceneAnimation fader;
    public string menuSceneName = "MainMenu";    

    public void Menu()
    {
        fader.FadeTo(menuSceneName);
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("PLEVEL", nextLevelIndex);
        PlayerPrefs.SetInt("PMONEY", PlayerStats.Money);
        PlayerPrefs.SetInt("PLIFE", PlayerStats.Lives);
        fader.FadeTo(nextLevel);
    }
}
