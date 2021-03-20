using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void selectStandardTurret()
    {
        Debug.Log("standard turret selected");
        buildManager.selectTurretToBuild(standardTurret);
    }

    public void selectMissileLauncher()
    {
        Debug.Log("missile selected");
        buildManager.selectTurretToBuild(missileLauncher);
    }
}
