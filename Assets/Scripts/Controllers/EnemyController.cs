using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float m_lookRadius = 5.0f;  // 5 by default for testing
    [SerializeField]
    private float distToPlayer;

    // AI-specific
    Transform m_target;
    NavMeshAgent m_agent;


    // Start is called before the first frame update
    void Start()
    {
        GameObject m_player = GameObject.Find("Player");
        // AI searches for the player
        m_target = m_player.transform;

        m_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance between AI agent and player object
        distToPlayer = Vector3.Distance(m_target.position, transform.position);

        if (distToPlayer <= m_lookRadius)
        {
            m_agent.SetDestination(m_target.position);
        }
    }

    // Showing draw distance of the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_lookRadius);
    }
}
