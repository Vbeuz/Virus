using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverList : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject solverPrefabs;
    public GameObject solverUIPrefabs;
    public List<string> _name = new List<string>();

    public SolverShow solverShow;
    public List<SolverUI> uiObjects = new List<SolverUI>();
    public List<CharacterController> characterData = new List<CharacterController>();

    public void AddNewUI()
    {
        var newSolver = Instantiate(solverPrefabs).GetComponent<CharacterController>();
        var newUI = Instantiate(solverUIPrefabs, scrollRect.content).GetComponent<SolverUI>();

        newSolver.characterData.ID = PlayerData._ID;
        newSolver.characterData.name = _name[Random.Range(0, _name.Count)];
        newSolver.characterData.level = 1;
        newSolver.characterData.hp = Random.Range(20, 50);
        newSolver.characterData.damage = Random.Range(1, 10);
        newSolver.characterData.speed = Random.Range(10, 20);

        newUI.characterData.ID = PlayerData._ID;
        newUI.characterData.name = newSolver.characterData.name;
        newUI.characterData.level = newSolver.characterData.level;
        newUI.characterData.hp = newSolver.characterData.hp;
        newUI.characterData.damage = newSolver.characterData.damage;
        newUI.characterData.speed = newSolver.characterData.speed;


        characterData.Add(newSolver);
        uiObjects.Add(newUI);
        solverShow.solverUIs.Add(newUI);

        PlayerData._ID++;
    }
}
