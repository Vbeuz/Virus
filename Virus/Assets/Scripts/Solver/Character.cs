using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
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

    NavMeshAgent agent;
    Transform target;

    bool isWalk;
    public bool isVirusing;

    void Start()
    {
        normal_state = Normal_State.Idle;
        _solverData = GetComponentInParent<SolverDataBase>();
        player = GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();

        _solverData.character.Add(this);
        FloorButton.characters.Add(this);
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
                    Walk();
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
                    player.CheckSolver(characterData.ID);
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

    #region State
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

    void Walk()
    {
        if (target == null && target != GameObject.Find("WalkBase"))
        {
            target = GameObject.Find("WalkBase").transform;
        }

        agent.SetDestination(target.position);
    }
    #endregion
}