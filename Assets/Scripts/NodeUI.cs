using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TMP_Text upgradeCostText;

    public Button upgradeButton;

    public TMP_Text sellAmountText;

    private Node target;

    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        { 
            upgradeCostText.text = target.turretBlueprint.upgradedCost + "eur";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "D!";
            upgradeButton.interactable = false;
        }

        sellAmountText.text = target.turretBlueprint.GetSellAmount() + "?";
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
