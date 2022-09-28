using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlining : MonoBehaviour
{
    Outline outline;
    CharacterController characterController;

    void Start()
    {
        outline = GetComponent<Outline>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.characterData.isVirused)
        {
            outline.OutlineColor = Color.red;
        }
        else
        {
            outline.OutlineColor = Color.cyan;
        }
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
