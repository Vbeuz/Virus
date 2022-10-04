using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolverDataBase : MonoBehaviour
{
    public List<Character> character = new List<Character>();

    void Update()
    {
        for (int i = 0; i < character.Count; i++)
        {
            if (character[i].characterData.isVirusing && !character[i].isVirusing)
            {
                StartCoroutine(Virusing(i));
            }
        }
    }

    IEnumerator Virusing(int _i)
    {
        character[_i].isVirusing = true;
        yield return new WaitForSeconds(1f + (character[_i].characterData.level / 2f));
        character[_i].characterData.virusing += 0.5f;

        if (character[_i].characterData.virusing >= 10f)
        {
            character[_i].characterData.isVirusing = false;
            character[_i].characterData.isVirused = true;
            PlayerData.floor_Virused[character[_i].characterData.floor - 1, character[_i].characterData.area] = true;

            PlayerData.virused++;
        }
        character[_i].isVirusing = false;
    }

}
