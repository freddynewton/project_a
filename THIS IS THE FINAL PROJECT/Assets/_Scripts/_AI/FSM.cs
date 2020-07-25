using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM : MonoBehaviour
{
    [Header("Action")]
    public Action[] actions;
    [HideInInspector] List<Action> actionList = new List<Action>();

    [Header("AI Settings")]
    public AISettings settings;

    public enum behaviorType
    {
        idle,
        searching,
        attacking,
        flee
    }

    [HideInInspector] public float healthTrait;
    [HideInInspector] public float attackTrait;
    [Header("Tick Rate")]
    [Range(0, 10)] public float TickRate;
    [Range(0, 10)] public float attackTraitTickValue;


    [HideInInspector] public behaviorType behavior;

    [HideInInspector] public StatHandler statHandler;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    private void Start()
    {
        statHandler = gameObject.GetComponent<StatHandler>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (statHandler.isEnemy)
        {
            updateAI();
        }
    }

    private void updateAI()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(evaluateData(1));
        StartCoroutine(decideState(1));
        StartCoroutine(traitTimer());
    }

    IEnumerator traitTimer()
    {
        attackTrait += attackTrait;
        yield return new WaitForSeconds(TickRate);
    }

    IEnumerator evaluateData(float time)
    {
        healthTrait = statHandler.currentHealth / statHandler.stats.Health;
        yield return new WaitForSeconds(time);
    }

    IEnumerator decideState(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
