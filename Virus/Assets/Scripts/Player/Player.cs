using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SolverList SolverList;

    public GameObject solverCheckList;
    public GameObject solverLists;
    public GameObject solver;
    public GameObject solverEquipUI;

    bool OnOff = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SolverList.AddNewUI();
        }
        OnOffSolverCheckList();
    }

    public void OnOffSolverCheckList()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!OnOff)
            {
                solverCheckList.SetActive(true);
                solverLists.SetActive(true);
                solver.SetActive(false);
                solverEquipUI.SetActive(false);
                OnOff = solverCheckList.activeSelf;
            }
            else
            {
                solverCheckList.SetActive(false);
                solverEquipUI.SetActive(false);
                OnOff = solverCheckList.activeSelf;
            }
        }
    }
}
