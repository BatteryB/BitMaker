using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEvent : MonoBehaviour
{
    private Color activeColor = new Color32(90, 230, 255, 255);
    private Color commonColor = Color.white;
    private Renderer objRenderer;
    private string[] obj;

    void Start()
    {
        obj = this.gameObject.name.Split('_');
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (obj[0] == "bitObject" && isObjectClicked())
        {
            if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "default")
            {
                SetObjectState(activeColor, "active");
            }
            else if (Input.GetMouseButtonDown(1) && this.gameObject.tag == "active")
            {
                SetObjectState(commonColor, "default");
            }
        }
    }

    bool isObjectClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void SetObjectState(Color color, string tag)
    {
        objRenderer.material.color = color;
        this.gameObject.tag = tag;
    }
}
