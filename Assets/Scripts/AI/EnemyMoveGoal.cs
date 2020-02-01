using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveGoal : MonoBehaviour
{
    [SerializeField]
    public Transform[] m_goals; // container of nodes

    // Current destination set for each
    // node-to-node travel
    private int destPoint = 0;

    [SerializeField]
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Set false for continous movement between nodes 
        // as it's set to on by default
        agent.autoBraking = false;

        GoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GoNextPoint()
    {
        // prerequisite check for container being empty
        if (m_goals.Length == 0)
        {
            print("Node container empty. Possible incomplete NavMesh.");
            return;
        }

        // Move to current selected node in container
        agent.destination = m_goals[destPoint].position;

        // When we move to the new point, the container will
        // increment by one node so we get the new updated position
        destPoint = (destPoint + 1) % m_goals.Length;
    }
}
