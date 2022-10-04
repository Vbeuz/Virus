using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public GameObject floor_ui;
    public SolverShow solverShow;

    bool onoff;

    private void Update()
    {
        onoff = floor_ui.activeSelf;
    }

    public void OnOff()
    {
        if (!onoff)
        {
            floor_ui.SetActive(true);
        }
        else
        {
            floor_ui.SetActive(false);
        }
    }



    public void Floor1()
    {

    }
    
    public void Floor2()
    {

    }
    
    public void Floor3()
    {

    }
    
    public void Floor4()
    {

    }
}
