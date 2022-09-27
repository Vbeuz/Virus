using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterData characterData;

    void Start()
    {

    }

    private void Update()
    {
        if (characterData.isVirusing)
        {

        }
    }

    IEnumerator Virusing()
    {
        yield return new WaitForSeconds(5f + (characterData.level / 2f));
        characterData.virusing += 0.1f;
    }
}