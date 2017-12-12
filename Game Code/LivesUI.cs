using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update ()
    {
        livesText.text = "Elixir: " + PlayerStats.Lives.ToString();
        if (PlayerStats.Lives <= 0f)
            livesText.text = "Lol you ded nigguh";
	}
}
