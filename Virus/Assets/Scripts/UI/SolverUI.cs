using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverUI : MonoBehaviour
{
    public SolverData characterData;

    public Text dataTxt;
    public Button showButton;

    [SerializeField] SolverShow solverShow;
    [SerializeField] GameObject solverList;

    void Awake()
    {
        ResetUI();

        solverShow = GameObject.Find("Solver_Data").GetComponent<SolverShow>();
        solverList = GameObject.Find("SolverList");
        showButton.onClick.AddListener(() => solverShow.Show(characterData.ID));
    }

    private void Start()
    {
        ResetUI();
    }
    
    public void ResetUI()
    {
        dataTxt.text = 
            $"Name : {characterData.name}\n" +
            $"Leve : {characterData.level}\n" +
            $"HP : {characterData.hp}\n" +
            $"Damage : {characterData.damage}\n" +
            $"Speed : {characterData.speed}\n" +
            $"Floor : ";
    }

    public void ShowData()
    {
        solverList.SetActive(false);
    }
}
