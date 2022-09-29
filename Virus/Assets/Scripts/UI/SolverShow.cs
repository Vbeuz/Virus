using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverShow : MonoBehaviour
{
    public List<SolverUI> solverUIs = new List<SolverUI>();
    public GameObject data;
    public Text dataTxt;
    public Text floorTxt;

    public Image[] Item;

    public void Show(int index)
    {
        Debug.Log("Show");
        dataTxt.text = solverUIs[index].dataTxt.text;
        floorTxt.text = solverUIs[index].characterData.floor.ToString();
        data.gameObject.SetActive(true);
    }
}
