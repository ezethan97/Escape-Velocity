using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Giant_controller : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 20f;
    [SerializeField] float damage = 50f;
    [SerializeField] float rotationSpeed = 20;

    NavMeshAgent navMeshAgent;
    Animator EnemyAnimator;
    PlayerHP HP;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
        HP = target.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
            EnemyAnimator.SetTrigger("Provoked");
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerHP HP = target.GetComponent<PlayerHP>();
            HP.DamageTaken(damage);
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
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            ChaseTarget();
            EnemyAnimator.SetBool("Attacking", false);
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
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
}
