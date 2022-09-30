using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlining : MonoBehaviour
{
    Camera mainCam;

    Outline outline;
    Character character;

    void Start()
    {
        mainCam = Camera.main;
        outline = GetComponent<Outline>();
        character = GetComponent<Character>();
    }

    void Update()
    {
        if (character.characterData.isVirused)
        {
            outline.OutlineColor = Color.red;
        }
        else
        {
            outline.OutlineColor = Color.cyan;
        }

        Outlined();
    }

    public void Outlined()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("Solver");

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            if (this.gameObject == hit.collider.gameObject)
            {
                this.outline.enabled = true;
            }
            else
            {
                outline.enabled = false;
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}
