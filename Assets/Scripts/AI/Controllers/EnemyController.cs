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
    GameObject m_player;

    void Start()
    {
        m_player = GameObject.Find("Player");
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

            if (distToPlayer <= m_agent.stoppingDistance)
            {
                // Place Attacking lines here
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        // Getting direction to player with forward vector
        Vector3 direction = (m_target.position - transform.position).normalized;
        // Gets correct rotation matrix for facing when following player
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.Equals(m_player);

        // Do damage to player
    }

    // Showing draw distance of the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_lookRadius);
    }
}
