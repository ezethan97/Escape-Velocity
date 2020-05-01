using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class grenadierController : MonoBehaviour
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
    void Start()
    {
        target = FindObjectOfType<PlayerHP>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
        EnemyAnimator.SetTrigger("Moving");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
            EnemyAnimator.Play("GrenadierWalk");
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
            GetComponent<Animator>().SetBool("Attacking", false);
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //trigger animation enemy attack target
            FaceTarget();
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Moving");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attacking",true);
        PlayerHP HP = target.GetComponent<PlayerHP>();
        HP.DamageTaken(damage);
    }
}
