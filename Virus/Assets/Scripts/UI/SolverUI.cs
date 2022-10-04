using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverUI : MonoBehaviour
{
    public SolverData characterData;
    public Character solver;

    public Text dataTxt;
    public Button showButton;

    [SerializeField] Player player;
    [SerializeField] SolverList solverList;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        solverList = GameObject.Find("Player").GetComponent<SolverList>();

        showButton.onClick.AddListener(() => player.CheckSolver(characterData.ID));


        solver = GameObject.FindGameObjectsWithTag("Solver")[characterData.ID].GetComponent<Character>();
    }

    private void Update()
    {
        ResetUI();
    }

    public void ResetUI()
    {
        if (solver != null)
        {
            characterData = solver.characterData;
        }

        dataTxt.text = 
            $"Name : {characterData.name}\n" +
            $"Leve : {characterData.level}\n" +
            $"HP : {characterData.hp}\n" +
            $"Damage : {characterData.damage}\n" +
            $"Speed : {characterData.speed}\n" +
            $"Floor : ";
    }
}
