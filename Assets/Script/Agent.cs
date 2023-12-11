using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private GameObject Destination;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InvokeRepeating("GoToDestination", 0f, 0.5f);
    }

    public void GoToDestination()
    {
        agent.SetDestination(Destination.transform.position);
    }
}
