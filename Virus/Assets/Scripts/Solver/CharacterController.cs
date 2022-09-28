using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public enum Normal_State
    {
        Idle,
        Move,
        Walk,
        Die
    }

    public CharacterData characterData;

    public Normal_State normal_state;

    bool isWalk;
    bool isVirusing;

    void Start()
    {
        normal_state = Normal_State.Idle;
    }

    private void Update()
    {
        if (characterData.isVirusing && !isVirusing)
        {
            StartCoroutine(Virusing());
        }

        if (!characterData.isVirused)
        {
            switch (normal_state)
            {
                case Normal_State.Idle:
                    Idle();
                    break;
                case Normal_State.Move:
                    Move();
                    break;
                case Normal_State.Walk:
                    break;
                case Normal_State.Die:
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator Virusing()
    {
        isVirusing = true;
        yield return new WaitForSeconds(1f + (characterData.level / 2f));
        characterData.virusing += 0.5f;

        if (characterData.virusing >= 10f)
        {
            characterData.isVirusing = false;
            characterData.isVirused = true;

            PlayerData.virused++;
        }
        isVirusing = false;
    }

    void Idle()
    {
        if (!isWalk)
        {
            StartCoroutine(IdleChange());
        }
    }

    IEnumerator IdleChange()
    {
        yield return new WaitForSeconds(3f);
        normal_state = Normal_State.Move;
    }

    void Move()
    {
        
    }

    IEnumerator MoveChange()
    {
        yield return new WaitForSeconds(3f);
    }
}