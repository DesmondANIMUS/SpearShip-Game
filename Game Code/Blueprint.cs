using UnityEngine;

[System.Serializable]
public class Blueprint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int upgradeCost;
    public int sellingPrice;
    public GameObject buildEffect;
    public GameObject sellEffect;
}
