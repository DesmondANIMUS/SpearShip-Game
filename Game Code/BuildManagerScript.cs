using UnityEngine;

public class BuildManagerScript : MonoBehaviour
{
    private Blueprint turretToBuild;
    private NodeScript selectedNode;
    public static BuildManagerScript instance;
    public NodeUIScript nodeUI;    
    
    void Awake ()
    {
        instance = this;
	}
	
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }  
    public bool HasUpgradeMoney { get { return PlayerStats.Money >= turretToBuild.upgradeCost; } }

    public void SelectTurretToBuild(Blueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public Blueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(NodeScript node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
