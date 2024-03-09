using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Enemies : MonoBehaviour
    {
        public float lookradius = 10f;
        private Transform target;
        private NavMeshAgent agent;
        private void Start()
        {
            target = PlayerManager.instance.player.transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookradius)
            {
                agent.SetDestination(target.position);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color=Color.red;
            Gizmos.DrawWireSphere(transform.position, lookradius);
        }
        /* public NavMeshAgent agent;
         public Transform player;
         public LayerMask whatIsground, whatIsplayer;

         //Pour patroler
         public Vector3 walkPoint;
         bool walkPointSet;
         public float walkPointRange;

         //attaque
         public float timeBetweenAttacks;
         private bool alreadyAttacked;

         //état de l'ennemi
         public float sightRange, attackRange;
         public bool playerInSightRange, playerInAttackRange;
         public float health;

         private void Update()
         {
             //on regarde si le player est en vue ou dans la zone d'attaque
             playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsplayer);
             playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsplayer);

             if (!playerInSightRange&& !playerInAttackRange)
             {
                 Patroling();
             }
             if (playerInSightRange&& !playerInAttackRange)
             {
                 ChasePlayer();
             }
             if (playerInSightRange&& playerInAttackRange)
             {
                 AttackPlayer();
             }
         }

         public void Awake()
         {
             player = GameObject.Find("Player").transform;
             agent = GetComponent<NavMeshAgent>();
         }
         private void Patroling()
         {
             if (!walkPointSet)
             {
                 SearchWalkPoint();
             }

             if (walkPointSet)
             {
                 agent.SetDestination(walkPoint);
             }

             Vector3 distanceToWalkPoint = transform.position - walkPoint;
             if (distanceToWalkPoint.magnitude<1f)
             {
                 walkPointSet = false;
             }
         }

         private void SearchWalkPoint()
         {
             float randomZ = Random.Range(-walkPointRange, walkPointRange);
             float randomX = Random.Range(-walkPointRange, walkPointRange);

             walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
             if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsground))
             {
                 walkPointSet = true;
             }
         }
         private void ChasePlayer()
         {
             agent.SetDestination(player.position);
         }
         private void AttackPlayer()
         {
             //ne pas faire bouger l'ennemi quand il attaque
             agent.SetDestination(transform.position);

             transform.LookAt(player);

             if (!alreadyAttacked)
             {
                 alreadyAttacked = true;
                 Invoke(nameof(ResetAttack),timeBetweenAttacks);
             }
         }
         private void ResetAttack()
         {
             alreadyAttacked = false;
         }

         public void TakeDamage(int damage)
         {
             health = health - damage;
             if (health<=0)
             {
                 Invoke(nameof(DestroyEnemy), 0.5f);
             }
         }
         private void DestroyEnemy()
         {
             Destroy(gameObject);
         }*/
    }
}
