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

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;

    }
}
