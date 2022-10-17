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
        Debug.Log("bought!");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasedSuperTurret()
    {
        buildManager.SetTurretToBuild(buildManager.superTurretPrefab);
    }
}
