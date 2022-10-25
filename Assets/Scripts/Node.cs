using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Not mandatory*")]
    public GameObject turret;

    private Color startColor;

    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if(turret != null)
        {
            Debug.Log("This place is occupied!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
