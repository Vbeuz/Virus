using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PlayerLoadScene")
        {
            SceneManager.LoadScene("Floor1");
        }
    }


    public void Floor1()
    {
        SceneManager.LoadScene("Floor1");
        PlayerData.floor = 0;
    }
    public void Floor2()
    {
        SceneManager.LoadScene("Floor2");
        PlayerData.floor = 1;
    }
    public void Floor3()
    {
        SceneManager.LoadScene("Floor3");
        PlayerData.floor = 2;
    }
    public void Floor4()
    {
        SceneManager.LoadScene("Floor4");
        PlayerData.floor = 3;
    }
}
