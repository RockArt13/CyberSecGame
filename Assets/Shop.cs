using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchasedSimpleTurret()
    {
        Debug.Log("Simple Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasedSuperTurret()
    {
        Debug.Log("Super Turret Selected");
        buildManager.SetTurretToBuild(buildManager.superTurretPrefab);
    }
}
