using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Camera mainCam;

    public SolverList SolverList;

    public GameObject[] solvers_floor;

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
        if (SceneManager.GetActiveScene().name == "Floor1")
        {
            solvers_floor[0].SetActive(true);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Floor2")
        {
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(true);
            solvers_floor[2].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Floor")
        {
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(true);
        }
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
