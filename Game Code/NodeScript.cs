using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour
{
    public Color nodeSelectedColor;    
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;
    private Color noMoney;

    private static int i = 0;
    private static bool OneFavor = false;


    BuildManagerScript buildManager;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public Blueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        noMoney = Color.red;
        buildManager = BuildManagerScript.instance;
	}
	
    private void OnMouseEnter()
    {
        if (!(buildManager.CanBuild))
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.HasMoney)
            rend.material.color = nodeSelectedColor;
        else
            rend.material.color = noMoney;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!(buildManager.CanBuild))
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(Blueprint blue)
    {
        if (PlayerStats.Money < blue.cost)
        {
            Debug.Log("You need more Bitcoins."); i++;

            if ((i > 5) && (OneFavor == false))
            {
                Debug.Log("Fine if you want a turret so bad then I'll just give it to you");
                PlayerStats.Money += 100;
                OneFavor = true;
            }

            return;
        }

        PlayerStats.Money -= blue.cost; i = 0;        

        var _turret = Instantiate(blue.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blue;

        GameObject effect = Instantiate(blue.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough Bitcoins"); i++;

            if ((i > 5) && (OneFavor == false))
            {
                Debug.Log("Fine if you want a turret so bad then I'll just give it to you");
                PlayerStats.Money += 100;
                OneFavor = true;
            }

            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost; i = 0;

        // Get rid of the old turret
        Destroy(turret);

        // Build a new one
        var _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;        

        GameObject effect = Instantiate(turretBlueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.sellingPrice;
        GameObject effect = Instantiate(turretBlueprint.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(turret);
        turretBlueprint = null;        
    }

    internal Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
