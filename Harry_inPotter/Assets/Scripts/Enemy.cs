using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyAttack enemyAttack;
    Animator zombieAnim;

    NavMeshAgent Agent;
    public Transform Target;
    public Transform emptyTarget;

    public float distance;
    public float mainTimer = -1f;
    public float exitTimer = 5f;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        zombieAnim = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, Target.transform.position);

        Agent.destination = Target.position;
        zombieAnim.SetFloat("Speed", distance);

        if (distance < 6f)
        {
            mainTimer += Time.deltaTime * 2;

            transform.LookAt(Target);
            zombieAnim.SetBool("Attack", true);
            Agent.destination = emptyTarget.position;

            if (mainTimer >= exitTimer)
            {
                enemyAttack.EnemyShoot();
                mainTimer = 0;
            }

        }
            else
            {
                Agent.destination = Target.position;
                zombieAnim.SetFloat("Speed", distance);
                zombieAnim.SetBool("Attack", false);
            }

        /*
        if (distance < 5f)
        {
            Agent.destination = emptyTarget.position;
        }
        */
    }
}
