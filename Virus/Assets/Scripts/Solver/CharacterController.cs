using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Walk,
        Die
    }

    public CharacterData characterData;

    public State state;

    bool isWalk;

    void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (characterData.isVirusing)
        {
            StartCoroutine(Virusing());
        }

        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Walk:
                break;
            case State.Die:
                break;
            default:
                break;
        }
    }

    IEnumerator Virusing()
    {
        yield return new WaitForSeconds(5f + (characterData.level / 2f));
        characterData.virusing += 0.1f;
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
        state = State.Move;
    }

    void Move()
    {
        
    }

    IEnumerator MoveChange()
    {
        yield return new WaitForSeconds(3f);
    }
}