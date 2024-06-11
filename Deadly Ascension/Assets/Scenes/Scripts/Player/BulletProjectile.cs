using System;
using Enemy;
using UnityEngine;
using Mirror;

namespace Bullet
{
    public class BulletProjectile : NetworkBehaviour
    {
        [SerializeField] private Transform vfxHitGreen;
        [SerializeField] private Transform vfxHitRed;

        public Rigidbody bulletRigidbody;

        public void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        public void Start()
        {
            float speed = 30f;
            bulletRigidbody.velocity = transform.forward * speed;
        }

        public void OnTriggerEnter(Collider other)
        {
            
            if (other.GetComponent<BulletTarget>()!=null)
            {
                Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

                Enemies enemy = other.GetComponent<Enemies>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }

            }
            else
            {
                Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
    }
}
