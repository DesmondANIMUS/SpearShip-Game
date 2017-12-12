using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManagerScript buildManager;
    public Blueprint standardTurret;
    public Blueprint missileLauncher;
    public Blueprint laserBeamer;

	// Use this for initialization
	void Start ()
    {
        buildManager = BuildManagerScript.instance;
	}
	
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
