using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Mirror;

namespace Enemy
{
    public class Enemies : NetworkBehaviour
    {
        public float lookradius = 10f;
        private NavMeshAgent agent;
        private Animator enemy;
        [SerializeField] private float health, maxHealth = 6f;
        private Vector3 lastPlayerPosition;
        private bool playerIsMoving = false;

        private Transform target;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Animator>();
            health = maxHealth;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerTakeDamage damageable = collision.gameObject.GetComponent<PlayerTakeDamage>();
                if (damageable != null)
                {
                    damageable.TakeDamage(1);
                }
            }
        }

        private void Update()
        {
            if (!isServer) return;

            FindClosestPlayer();

            if (target != null)
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance <= lookradius)
                {
                    enemy.SetBool("see player", true);
                    agent.SetDestination(target.position);

                    if (distance <= agent.stoppingDistance)
                    {
                        FaceTarget();
                    }
                }
                else
                {
                    enemy.SetBool("see player", false);
                    target = null;
                }

                if (target.position != lastPlayerPosition)
                {
                    playerIsMoving = true;
                    lastPlayerPosition = target.position;
                }
                else
                {
                    playerIsMoving = false;
                }
            }
        }

        void FindClosestPlayer()
        {
            float closestDistance = lookradius;
            target = null;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= closestDistance)
                {
                    target = player.transform;
                    closestDistance = distance;
                }
            }
        }

        void FaceTarget()
        {
            if (target == null) return;
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookradius);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enemy collided with: " + other.gameObject.name);
            if (other.CompareTag("Player"))
            {
             
                    CmdAttack(other.gameObject);
                
            }
        }


        [Command]
        void CmdAttack(GameObject playerObj)
        {
            Debug.Log("CmdAttack called on: " + playerObj.name);
            RpcAttack(playerObj);
        }

        [ClientRpc]
        void RpcAttack(GameObject playerObj)
        {
            Debug.Log("RpcAttack called on: " + playerObj.name);
            PlayerTakeDamage player = playerObj.GetComponent<PlayerTakeDamage>();
            if (player != null)
            {
                Debug.Log("PlayerTakeDamage component found on: " + playerObj.name);
                player.TakeDamage(1);
                StartCoroutine(CheckPlayerMovement(player));
            }
        }

        IEnumerator CheckPlayerMovement(PlayerTakeDamage player)
        {
            yield return new WaitForSeconds(1f);

            if (!playerIsMoving)
            {
                if (player != null)
                {
                    player.TakeDamage(1);
                    StartCoroutine(CheckPlayerMovement(player));
                }
            }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                // Ajouter animation de mort
            }
        }
    }
}