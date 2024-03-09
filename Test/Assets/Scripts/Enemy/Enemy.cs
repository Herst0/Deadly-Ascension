using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Enemies : MonoBehaviour
    {
        public int enemyHP = 100;
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

                if (distance<= agent.stoppingDistance)
                {
                    //attaque le player (je m'en occupe plus tard)
                    FaceTarget(); //faire face au player
                }
            }
        }

        void FaceTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color=Color.red;
            Gizmos.DrawWireSphere(transform.position, lookradius);
        }

        public void TakeDamage(int damageAmount)
        {
            enemyHP = enemyHP - damageAmount;
            if (enemyHP<=0)
            {
                //death animation
            }
            else
            {
                //damage animation
            }
        }
    }
}
