using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Camera mainCam;

    public SolverList SolverList;

    #region Solver
    public GameObject solver_UI_Group;
    public GameObject solverCheckList;
    public GameObject solverLists;
    public GameObject solver;
    public GameObject solverEquipUI;
    public Text solverCount;
    #endregion

    public GameObject floorDesctop_Group;

    bool CheckListOnOff = false;


    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        floorDesctop_Group.SetActive(!CheckListOnOff);
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SolverList.AddNewUI();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnOffSolverCheckList();
        }
        solverCount.text =
            $"Solver Count : {PlayerData._ID - PlayerData.die}/{PlayerData.MaxSolverCont}" +
            $"\nVirused Solver : {PlayerData.virused}/{PlayerData.MaxSolverCont}";
    }

    public void OnOffSolverCheckList()
    {
        if (!CheckListOnOff)
        {
            solver_UI_Group.SetActive(true);
            solverCheckList.SetActive(true);
            solverLists.SetActive(true);
            solver.SetActive(false);
            solverEquipUI.SetActive(false);
            CheckListOnOff = solverCheckList.activeSelf;
        }
        else
        {
            solverCheckList.SetActive(false);
            solverEquipUI.SetActive(false);
            CheckListOnOff = solverCheckList.activeSelf;
        }
    }
}
