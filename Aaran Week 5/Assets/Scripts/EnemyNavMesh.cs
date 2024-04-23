using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
     agent = GetComponent<NavMeshAgent>();
     player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
