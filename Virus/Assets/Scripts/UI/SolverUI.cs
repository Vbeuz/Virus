using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverUI : MonoBehaviour
{
    public CharacterData characterData;

    public Text dataTxt;
    public Button showButton;

    [SerializeField] SolverShow solverShow;
    [SerializeField] GameObject solverList;

    void Start()
    {
        ResetUI();

        solverShow = GameObject.Find("Solver_Data").GetComponent<SolverShow>();
        solverList = GameObject.Find("SolverList");
        showButton.onClick.AddListener(() => solverShow.Show(characterData.ID));
    }

    void Update()
    {
        
    }

    public void ResetUI()
    {
        dataTxt.text = 
            $"Name : {characterData.name}\n" +
            $"Leve : {characterData.level}\n" +
            $"HP : {characterData.hp}\n" +
            $"Damage : {characterData.damage}\n" +
            $"Speed : {characterData.speed}\n";
    }

    public void ShowData()
    {
        solverList.SetActive(false);
    }
}