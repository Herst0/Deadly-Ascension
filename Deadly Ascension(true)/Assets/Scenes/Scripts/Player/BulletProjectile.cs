using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletProjectile : MonoBehaviour
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
            BulletTarget bulletTarget = other.GetComponent<BulletTarget>();

            if (bulletTarget != null)
            {
                Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
                int damage = bulletTarget.damageAmount; // Obtenez les dégâts de BulletTarget

                Enemies enemy = other.GetComponent<Enemies>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                else
                {
                    EnemiesBoss enemyBoss = other.GetComponent<EnemiesBoss>();
                    if (enemyBoss != null)
                    {
                        enemyBoss.TakeDamage(damage);
                    }
                    else
                    {
                        ZombieLent zombieLent = other.GetComponent<ZombieLent>();
                        if (zombieLent != null)
                        {
                            zombieLent.TakeDamage(damage);
                        }
                    }
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