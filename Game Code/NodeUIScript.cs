using UnityEngine;
using UnityEngine.UI;

public class NodeUIScript : MonoBehaviour
{
    public GameObject UI;
    public Text upgradeCost;
    public Text sellingPrice;
    public Button upgradeButton;    

    private NodeScript target;    
    public void SetTarget(NodeScript _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (target.isUpgraded)
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "∞";
        }
        else
        {
            upgradeButton.interactable = true;
            upgradeCost.text = "Ƀ" + target.turretBlueprint.upgradeCost.ToString();
        }

        sellingPrice.text = "Ƀ" + target.turretBlueprint.sellingPrice.ToString();        
        UI.SetActive(true);        
    }
    
    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManagerScript.instance.DeselectNode(); 
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManagerScript.instance.DeselectNode();
    }
}
