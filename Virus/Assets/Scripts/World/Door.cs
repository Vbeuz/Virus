using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Animation[] ani;
    public Animation door_Lock;

    public int floor;
    public int roomNumber;
    public bool isOpen;

    void Update()
    {
        if (PlayerData.floor_Virused[floor, roomNumber])
        {
            door_Lock.Play("LockedDoor_01_Open");
        }
        else
        {
            ani[0].Play("Door_01_Close");
            ani[1].Play("Door_01_Close");
            door_Lock.Play("LockedDoor_01_Close");
        }
    }

    public void DoorOnOff()
    {
        if (!PlayerData.floor_Virused[floor, roomNumber])
        {
            if (!isOpen)
            {
                ani[0].Play("Door_01_Open");
                ani[1].Play("Door_01_Open");
            }
            else
            {
                ani[0].Play("Door_01_Close");
                ani[1].Play("Door_01_Close");
            }
        }
    }
}
