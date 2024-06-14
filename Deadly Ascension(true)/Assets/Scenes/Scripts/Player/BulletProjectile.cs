using UnityEngine;
using Mirror;

public class BulletProjectile : NetworkBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidbody;
    private float damage = 1f;

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
        if (!isServer)
            return;

        if (other.GetComponent<BulletTarget>() != null)
        {
            // Instantiate green hit VFX on all clients
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

            /*Enemies enemy = other.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }*/
        }
        else
        {
            // Instantiate red hit VFX on all clients
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

        // Destroy the bullet on all clients
        NetworkServer.Destroy(gameObject);
    }

    // Method to set the damage of the bullet
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
}