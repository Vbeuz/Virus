using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverUI : MonoBehaviour
{
    public SolverData characterData;

    public Text dataTxt;
    public Button showButton;

    [SerializeField] Player player;
    // [SerializeField] GameObject solverList;

    void Awake()
    {
        ResetUI();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        ResetUI();

        // solverList = GameObject.Find("SolverList");
        showButton.onClick.AddListener(() => player.CheckSolver(characterData.ID));
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
        // solverList.SetActive(false);
    }
}
