using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemiesBoss : MonoBehaviour
    {
        // public int enemyHP = 100;
        public float lookradius = 10f;
        private Transform target;
        private NavMeshAgent agent;
        private Animator enemy;
        [SerializeField] private float heath, maxHealth = 6f;
        private Vector3 lastPlayerPosition; // Dernière position connue du joueur
        private bool playerIsMoving = false; // Indique si le joueur est en mouvement
        [SerializeField] private GameObject spawnPrefab; // Prefab à faire spawn
        [SerializeField] private GameObject anotherPrefab; // Deuxième prefab à faire spawn
        [SerializeField] private Vector3 definedPosition; // Position définie pour le deuxième prefab

        public GameObject _medik;
        private void Start()
        {
            target = PlayerManager.instance.player.transform;
            agent = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Animator>();
            heath = maxHealth;
            lastPlayerPosition = target.position;
        }

        private void Update()
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookradius)
            {
                enemy.SetBool("see player", true);
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget(); //faire face au player
                }
            }
            else
            {
                enemy.SetBool("see player", false);
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

        void FaceTarget()
        {
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
            if (other.CompareTag("Player")) // Vérifie si le collider qui entre en collision est celui du joueur
            {
                Attack(); // Lance l'attaque si le joueur entre en collision avec l'ennemi
            }
        }

        void Attack()
        {
            // Ici, vous pouvez mettre le code pour infliger des dégâts au joueur
            PlayerTakeDamage player = target.GetComponent<PlayerTakeDamage>();
            if (player != null)
            {
                player.TakeDamage(1);
                StartCoroutine(CheckPlayerMovement());
            }
        }

        IEnumerator CheckPlayerMovement()
        {
            yield return new WaitForSeconds(1f); // Attendre 1 seconde

            if (!playerIsMoving)
            {
                PlayerTakeDamage player = target.GetComponent<PlayerTakeDamage>();
                if (player != null)
                {
                    player.TakeDamage(1); // Infliger des dégâts supplémentaires
                    StartCoroutine(CheckPlayerMovement());
                }
            }
        }

        public void TakeDamage(float damage)
        {
            heath -= damage;
            if (heath <= 0)
            {
                SpawnPrefab(); // Faire spawn le prefab
                SpawnAnotherPrefabAtDefinedPosition(); // Faire spawn l'autre prefab à la position définie
                Instantiate(_medik, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        void SpawnPrefab()
        {
            if (spawnPrefab != null)
            {
                Instantiate(spawnPrefab, transform.position, Quaternion.identity);
            }
        }

        void SpawnAnotherPrefabAtDefinedPosition()
        {
            if (anotherPrefab != null)
            {
                Instantiate(anotherPrefab, definedPosition, Quaternion.identity);
            }
        }
    }
}
