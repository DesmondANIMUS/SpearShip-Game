using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text roundsText; 
    public string mainMenu = "MainMenu";
    public SceneAnimation sceneAnimation;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneAnimation.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneAnimation.FadeTo(mainMenu);
    }
}
