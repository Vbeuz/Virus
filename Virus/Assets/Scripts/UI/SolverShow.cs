using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolverShow : MonoBehaviour
{
    public List<SolverUI> solverUIs = new List<SolverUI>();
    public GameObject data;
    public Text dataTxt;

    public Image[] Item;

    public void Show(int index)
    {
        dataTxt.text = solverUIs[index].dataTxt.text;
        data.gameObject.SetActive(true);
    }
}
