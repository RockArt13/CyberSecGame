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

    public GameObject buildEffect;



    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerState.Money >= turretToBuild.cost; } }

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

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5.0f);

        Debug.Log("Turret build: Current money status: " + PlayerState.Money);
    }

    public void SelectNode(Node node)
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
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        DeselectNode();

    }
}
