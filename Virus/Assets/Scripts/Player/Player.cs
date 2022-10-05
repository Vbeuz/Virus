using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera minimapCam;
    Camera mainCam;
    CharacterController controller;

    public float speed = 40;
    public float scrollSpeed = 10;

    public SolverList solverList;
    public SolverShow solverShow;
    public GameObject sl;

    [SerializeField] int nowScene;

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
        controller = GetComponent<CharacterController>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        CheckListOnOff = solverCheckList.activeSelf;
        floorDesctop_Group.SetActive(!CheckListOnOff);
        if (Input.GetKeyDown(KeyCode.F12))
        {
            solverList.AddNewUI();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnOffSolverCheckList();
        }

        solverCount.text =
            $"Solver Count : {PlayerData._ID - PlayerData.die}/{PlayerData.MaxSolverCont}" +
            $"\nVirused Solver : {PlayerData.virused}/{PlayerData.MaxSolverCont}";

        MonveControlling();

    }

    #region Solver
    public void OnOffSolverCheckList()
    {
        if (!CheckListOnOff)
        {
            solver_UI_Group.SetActive(true);
            solverCheckList.SetActive(true);
            solverLists.SetActive(true);
            solver.SetActive(false);
            solverEquipUI.SetActive(false);
        }
        else
        {
            solverCheckList.SetActive(false);
            solverEquipUI.SetActive(false);
        }
    }

    public void CheckSolver(int _char)
    {
        sl.SetActive(true);

        if (!CheckListOnOff)
        {
            OnOffSolverCheckList();
        }

        solverShow.Show(_char);

        sl.SetActive(false);
    }

    public void OffCheckSolver()
    {
        if (CheckListOnOff)
        {
            OnOffSolverCheckList();
        }
    }
    #endregion

    void MonveControlling()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed;
        float v = Input.GetAxisRaw("Vertical") * speed;
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed;

        Vector3 dir = new Vector3(h * mainCam.orthographicSize, 0, v * mainCam.orthographicSize);
        dir = dir.normalized;

        controller.Move(dir);

        mainCam.orthographicSize -= scroll;
        if (mainCam.orthographicSize < 5)
        {
            mainCam.orthographicSize = 5;
        }
        else if (mainCam.orthographicSize > 50)
        {
            mainCam.orthographicSize = 50;
        }
    }
}
