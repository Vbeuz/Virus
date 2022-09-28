using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheckUI : MonoBehaviour
{
    public GameObject moniter;

    bool OnOff;

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
