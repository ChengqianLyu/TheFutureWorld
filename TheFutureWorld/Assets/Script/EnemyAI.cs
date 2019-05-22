using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    private AggroDetection AggroDetection;
    private Transform target;

    private void Awake()
    {
        AggroDetection = GetComponent<AggroDetection>();
        AggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if(target != null)
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }

}
