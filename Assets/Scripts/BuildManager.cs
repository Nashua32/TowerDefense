using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject standardTurret;
    public GameObject missile;
    public GameObject buildEffect;

    
    private TurretBlueprint towerToBuild;

    public bool canBuild { get {return towerToBuild != null;}}
    public bool enoughMoney { get {return PlayerStats.money >= towerToBuild.cost;}}

    public void selectTurretToBuild(TurretBlueprint turret)
    {
        towerToBuild = turret;
    }

    public void buildTurretOn(Node node)
    {
        if (PlayerStats.money < towerToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }
        PlayerStats.money -= towerToBuild.cost;
        GameObject turret = (GameObject)Instantiate(towerToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.turretHere = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position + node.positionOffset, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Money left: " +PlayerStats.money);
    }
}
