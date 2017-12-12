using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;    
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        GameOver = false;
    }

    void Update ()
    {
        if (GameOver)
            return;
        if (PlayerStats.Lives <= 0f)
            EndGame();
	}

    private void EndGame()
    {
        Debug.Log("End game bla bla");
        GameOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameOver = true;
        completeLevelUI.SetActive(true);
    }
}
