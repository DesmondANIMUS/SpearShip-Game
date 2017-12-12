using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public string mainMenu = "MainMenu";    
    public SceneAnimation sceneAnimation;
    
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Toggle();
	}

    public void Toggle()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        if (pauseMenuUI.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        Toggle();
        sceneAnimation.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneAnimation.FadeTo(mainMenu);
    }
}
