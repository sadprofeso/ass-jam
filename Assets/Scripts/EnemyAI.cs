using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3f;
    public Transform player;
    private NavMeshAgent agent;
    private bool canMove = true;
    [SerializeField] private Rigidbody rb;

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
    
        Vector3 lookAtPosition = player.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);

        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.AddExplosionForce(10000f, transform.position, 100f);
        }
    }


}
