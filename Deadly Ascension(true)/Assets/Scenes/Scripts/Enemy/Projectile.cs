using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed = 10f;
    public float damage = 1f; // Dégâts infligés au joueur

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
        else
        {
            Debug.LogError("Rigidbody not found on Bullet!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTakeDamage player = other.GetComponent<PlayerTakeDamage>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Destroy(gameObject); // Détruire la balle après avoir touché le joueur
        }
        else if (!other.CompareTag("Enemy")) // Détruire la balle si elle touche autre chose que le joueur ou un ennemi
        {
            Destroy(gameObject);
        }
    }
}
