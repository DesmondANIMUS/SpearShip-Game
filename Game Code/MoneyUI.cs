using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text money;

	void Update ()
    {
        money.text = "Ƀ" + PlayerStats.Money.ToString();

        if (PlayerStats.Money == 0f)
            money.text = "You broke nigga .-.";
        else if (PlayerStats.Money <= -200f)
            money.text = "Yea, you really broke now .-.";
        else if (PlayerStats.Money <= -500f)
            money.text = "Consider restarting level .-.";
        
    }
}
