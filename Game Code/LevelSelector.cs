using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneAnimation fader;
    public Button[] buttons;
    public Text[] texts;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("PLEVEL", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if ( (i + 1) > levelReached)
            {
                buttons[i].interactable = false;
                texts[i].text = "∞";
            }
        }
    }

    public void SelectLevel(string levelName)
    {
        fader.FadeTo(levelName);    
    }
}
