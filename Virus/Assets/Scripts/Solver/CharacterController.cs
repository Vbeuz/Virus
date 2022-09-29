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

    public SolverData characterData;

    public Normal_State normal_state;
    Area _area;
    SolverDataBase _solverData;
    Player player;

    bool isWalk;
    public bool isVirusing;

    void Start()
    {
        normal_state = Normal_State.Idle;
        _solverData = GetComponentInParent<SolverDataBase>();
        player = GameObject.Find("Player").GetComponent<Player>();

        _solverData.characterControllers.Add(this);
    }

    private void Update()
    {
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

        CharacterClick();
    }

    public void CharacterClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Solver")))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    player.CheckSolver(this);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Area")
        {
            _area = other.GetComponent<Area>();
            characterData.area = _area.AreaNumber;
        }
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