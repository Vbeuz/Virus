using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolverDataBase : MonoBehaviour
{
    public List<CharacterController> characterControllers = new List<CharacterController>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characterControllers.Count; i++)
        {
            if (characterControllers[i].characterData.isVirusing && !characterControllers[i].isVirusing)
            {
                StartCoroutine(Virusing(i));
            }
        }
    }

    IEnumerator Virusing(int _i)
    {
        characterControllers[_i].isVirusing = true;
        yield return new WaitForSeconds(1f + (characterControllers[_i].characterData.level / 2f));
        characterControllers[_i].characterData.virusing += 0.5f;

        if (characterControllers[_i].characterData.virusing >= 10f)
        {
            characterControllers[_i].characterData.isVirusing = false;
            characterControllers[_i].characterData.isVirused = true;
            PlayerData.floor_Virused[characterControllers[_i].characterData.floor - 1, characterControllers[_i].characterData.area] = true;

            PlayerData.virused++;
        }
        characterControllers[_i].isVirusing = false;
    }

}
