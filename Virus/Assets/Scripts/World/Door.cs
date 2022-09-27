using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Animation ani;
    public Animation[] door_Lock;

    public int floor;
    public bool isOpen;

    void Update()
    {
        if (PlayerData.floor_Virused[floor])
        {

        }
    }

    public void DoorOnOff()
    {
        if (!PlayerData.floor_Virused[floor])
        {
            if (!isOpen)
            {
                ani.Play("Door_01_Open");
            }
            else
            {
                ani.Play("Door_01_Close");
            }
        }
        else
        {
            ani.Play("Door_01_Close");
            door_Lock[0].Play("Door_01_Close");
            door_Lock[1].Play("Door_01_Close");
        }
    }
}
