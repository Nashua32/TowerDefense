using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    public Color warningHoverColour;
    private Renderer rend;
    private Color normalcol;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turretHere;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        normalcol = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.canBuild)
        {
            return;
        }
        rend.material.color = hoverColour;
        if (!buildManager.enoughMoney || turretHere!=null)
        {
            rend.material.color = warningHoverColour;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = normalcol;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.canBuild)
            return;

        if (turretHere != null)
        {
            Debug.Log("you can't build here");
            return;
        }
        buildManager.buildTurretOn(this);
    }


}



