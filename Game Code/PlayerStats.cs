using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;
    public static int Lives;
    public int startLives = 10;
    public static int Rounds;
    
	void Start ()
    {
        Money = PlayerPrefs.GetInt("PMONEY", startMoney) + 300;
        Lives = PlayerPrefs.GetInt("PLIFE", startLives);
        Rounds = 0;                
    }	
}
