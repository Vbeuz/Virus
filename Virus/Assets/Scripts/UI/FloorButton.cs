using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public static List<Character> characters = new List<Character>();

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
        characters[solverShow.floor].characterData.floor = 1;
        characters[solverShow.floor].transform.position = Vector3.zero;
    }
    
    public void Floor2()
    {
        characters[solverShow.floor].characterData.floor = 2;
        characters[solverShow.floor].transform.position = Vector3.zero;
    }
    
    public void Floor3()
    {
        characters[solverShow.floor].characterData.floor = 3;
        characters[solverShow.floor].transform.position = Vector3.zero;
    }
    
    public void Floor4()
    {
        characters[solverShow.floor].characterData.floor = 4;
        characters[solverShow.floor].transform.position = Vector3.zero;
    }
}
