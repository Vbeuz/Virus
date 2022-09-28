using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
        floorDesctop_Group.SetActive(!CheckListOnOff);
        if (Input.GetKeyDown(KeyCode.F12))
        {
            solverList.AddNewUI();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnOffSolverCheckList();
        }
        CheckListOnOff = solverCheckList.activeSelf;


        solverCount.text =
            $"Solver Count : {PlayerData._ID - PlayerData.die}/{PlayerData.MaxSolverCont}" +
            $"\nVirused Solver : {PlayerData.virused}/{PlayerData.MaxSolverCont}";

        FloorScenes();
        if (Input.GetMouseButtonDown(0))
        {
            CheckSolver();
        }
    }
    void FloorScenes()
    {
        if (SceneManager.GetActiveScene().name == "Floor1" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(true);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Floor2" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(true);
            solvers_floor[2].SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Floor3" && nowScene != SceneManager.sceneCount)
        {
            nowScene = SceneManager.sceneCount;
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(true);
        }
        else if (nowScene != SceneManager.sceneCount)
        {
            solvers_floor[0].SetActive(false);
            solvers_floor[1].SetActive(false);
            solvers_floor[2].SetActive(false);
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

    void CheckSolver()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        CharacterController hitCharacter;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<CharacterController>())
            {
                hitCharacter = hit.transform.gameObject.GetComponent<CharacterController>();

                Debug.Log(hitCharacter.characterData.name);

                if (!CheckListOnOff)
                {
                    OnOffSolverCheckList();
                }
                sl.SetActive(false);
                solverShow.Show(hitCharacter.characterData.ID);
            }
            else
            {
                solverCheckList.SetActive(false);
                solverEquipUI.SetActive(false);
            }
        }
    }
}
