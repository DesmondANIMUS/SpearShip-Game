using UnityEngine;

public class HowToScript : MonoBehaviour
{
    public string mainMenu = "MainMenu";
    public SceneAnimation fade;

    public void BackToMenu()
    {
        fade.FadeTo(mainMenu);
    }
}
