using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{

    [SerializeField] float chaseRange = 3;
    [SerializeField] float damage = 20f;
    [SerializeField] float rotationSpeed = 10;
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator EnemyAnimator;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;

	// Use this for initialization
	void Start ()
    {
        target = FindObjectOfType<PlayerHP>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
            movingTrigger();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, GetComponent<NavMeshAgent>().stoppingDistance);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void EngageTarget()
    {
        if (distanceToTarget>= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            EnemyAnimator.SetBool("Attacking", false);
        }

        if (distanceToTarget<=navMeshAgent.stoppingDistance)
        {
            //trigger animation enemy attack target
            EnemyAnimator.SetBool("Attacking", true);
            FaceTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        PlayerHP HP = target.GetComponent<PlayerHP>();
        HP.DamageTaken(damage);
    }

    private void movingTrigger()
    {
        EnemyAnimator.SetTrigger("Moving");
    }
}
