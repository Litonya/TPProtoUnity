using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MedusaAgent : MonoBehaviour
{
    private NavMeshAgent agent;

    private float maxTimeWait = 4f;
    private float currentWaintingTime = 0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GoToNewDestination", 0f, 2f);
    }

    private void Update()
    {
        currentWaintingTime += Time.deltaTime;
    }

    void GoToNewDestination()
    {
        if (agent.remainingDistance == 0f ||currentWaintingTime>=maxTimeWait)
        {
            Vector3 destination = new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(2.5f, 7.5f));
            Debug.Log(destination);
            agent.SetDestination(destination);
            currentWaintingTime = 0;
        }
    }
}
