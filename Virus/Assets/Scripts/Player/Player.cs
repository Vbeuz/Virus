using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;


    public Camera minimapCam;
    Camera mainCam;

    public SolverList solverList;
    public SolverShow solverShow;
    public GameObject sl;

    public GameObject[] solvers_floor;

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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(Input.mousePosition, Vector3.forward * 10, Color.red);

            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
                // OffCheckSolver();
            }
        }


        solverCount.text =
            $"Solver Count : {PlayerData._ID - PlayerData.die}/{PlayerData.MaxSolverCont}" +
            $"\nVirused Solver : {PlayerData.virused}/{PlayerData.MaxSolverCont}";

        FloorScenes();
    }
    void FloorScenes()
    {
        if (SceneManager.GetActiveScene().name == "Floor1" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(true);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
            solvers_floor[3].SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Floor2" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(true);
            solvers_floor[2].SetActive(false);
            solvers_floor[3].SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Floor3" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(true);
            solvers_floor[3].SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Floor4" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
            solvers_floor[3].SetActive(true);
        }
        else if (nowScene != SceneManager.sceneCount)
        {
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
            solvers_floor[3].SetActive(false);
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
        }
        else
        {
            solverCheckList.SetActive(false);
            solverEquipUI.SetActive(false);
        }
    }

    public void CheckSolver(CharacterController _char)
    {
        sl.SetActive(true);

        if (!CheckListOnOff)
        {
            OnOffSolverCheckList();
        }

        solverShow.Show(_char.characterData.ID);

        sl.SetActive(false);
    }

    public void OffCheckSolver()
    {
        if (CheckListOnOff)
        {
            OnOffSolverCheckList();
        }
    }

    public void UI_Off()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

    }
}
