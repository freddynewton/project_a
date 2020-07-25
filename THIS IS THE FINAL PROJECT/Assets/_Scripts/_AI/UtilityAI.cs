using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UtilityAI : MonoBehaviour
{
    [Header("Actions")]
    public Action[] actions;

    [Header("Ai Settings")]
    public AISettings aiSettings;
    public float calculateDataRate = 1f;

    [HideInInspector] public float selfDanger;
    [HideInInspector] public float targetHealthProcentage;
    [HideInInspector] public float targetProximityFear;


    [HideInInspector] public StatHandler statHandler;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    private void Start()
    {
        statHandler = gameObject.GetComponent<StatHandler>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selfDanger);
        Debug.Log("Health %: " + statHandler.currentHealth / statHandler.stats.Health);
    }

    private void Awake()
    {
        StartCoroutine(calculate());
    }

    IEnumerator calculate()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            Debug.Log("calc stats");
            calculateStats();
            
            yield return new WaitForSeconds(calculateDataRate);
        }
    }

    public void calculateStats()
    {
        selfDanger = aiSettings.selfDanger.Evaluate(statHandler.currentHealth / statHandler.stats.Health);

        if (statHandler.Target != null)
        {
            StatHandler targetStats = statHandler.Target.GetComponent<StatHandler>();
            targetHealthProcentage = aiSettings.targetHealth.Evaluate(targetStats.currentHealth / targetStats.stats.Health);
            targetProximityFear = aiSettings.targetProximityFear.Evaluate(Vector2.Distance(gameObject.transform.position, statHandler.Target.transform.position) / aiSettings.maxRange);
            if (targetProximityFear > 1)
            {
                targetProximityFear = 1;
            }
        }
    }
}
