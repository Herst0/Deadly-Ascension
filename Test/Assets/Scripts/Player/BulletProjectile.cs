using UnityEngine;

namespace Player
{
    public class BulletProjectile : MonoBehaviour
    {

        private Rigidbody bulletRigidbody;

        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            float speed = 10f;
            bulletRigidbody.velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
