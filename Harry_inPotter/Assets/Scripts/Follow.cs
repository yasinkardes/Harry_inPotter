using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform Target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        agent.destination = Target.position;
    }
}
