using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : ACharacter
{
    
    [Header("Movement Settings")]
    public float speed = 3f;
    public Transform player;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;
        }
    }

    private void Update()
    {
        agent.speed = ACharacter.canMove ? speed : 0;
        Vector3 lookAtPosition = player.position;
        lookAtPosition.y = transform.position.y;
        SmoothLookAt(lookAtPosition);
        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collide();
        }
    }


    private void SmoothLookAt(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * Random.Range(5f, 15f));
        }
    }
}
