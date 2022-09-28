using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCheckUI : MonoBehaviour
{
    public Image[] Floor;

    public GameObject moniter;

    bool OnOff;

    void Update()
    {
        VirusedFloor();
    }

    public void VirusedFloor()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (PlayerData.floor_Virused[j, i] && Floor[j].color == Color.white)
                {
                    Floor[j].color = Color.red;
                }
            }
        }
    }

    public void FloorDesctopOnOff()
    {
        if (!OnOff)
        {
            moniter.SetActive(true);
            OnOff = true;
        }
        else
        {
            moniter.SetActive(false);
            OnOff = false;
        }
    }
}
