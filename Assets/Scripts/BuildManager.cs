using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Not singleton anymore");
            return;
        }
        instance = this;

    }


    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;



    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerState.Money < turretToBuild.cost)
        {
            Debug.Log("No money to buy!");
            return;
        }

        PlayerState.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

        node.turret = turret;

        Debug.Log("Turret build: Current money status: " + PlayerState.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;

    }
}
