using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    bool rechedDestinacion = true;
    Vector3 finalPosition = new Vector3(0, 0, 0);

    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > 30)
        {
            
            if (transform.position == finalPosition)
            {
                rechedDestinacion = true;
            }

            if (navMeshAgent.velocity.magnitude < 0.1f)
            {
                rechedDestinacion = true;
            }

            if (rechedDestinacion == false) 
            {
                return;
            }
            if (rechedDestinacion == true && distance > 30)
            {
                
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 30;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, 30, 1);
                finalPosition = hit.position;
                navMeshAgent.SetDestination(finalPosition);
                rechedDestinacion = false;
            }
            
            
        }
        else if (distance < 30)
        {
            if (target == null) return;
            navMeshAgent.SetDestination(target.position);
        }

    }
}
