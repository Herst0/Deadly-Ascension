using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTireur : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRange = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public GameObject xpPrefab; // Prefab de l'objet d'expérience
    public GameObject coinsPrefab; // Prefab de l'objet de pièces


    private Transform target;
    private Animator enemyAnimator;
    private bool isDead = false;
    private float health, maxHealth = 6f;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        enemyAnimator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            enemyAnimator.SetBool("see player", true);
            if (distance <= attackRange)
            {
                FaceTarget();

                ThirdPersonController playerController = target.GetComponent<ThirdPersonController>();
                if (playerController != null && playerController.isDodging)
                {
                    return; // Ne pas attaquer si le joueur est en train de dodger
                }

                Attack();
            }
        }
        else
        {
            enemyAnimator.SetBool("see player", false);
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
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Attack()
    {
        FireProjectile();
    }

    void FireProjectile()
    {
        if (projectilePrefab != null && firePoint != null && target != null)
        {
            // Calculer la direction vers le joueur
            Vector3 direction = (target.position - firePoint.position).normalized;

            // Instancier le projectile au firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Calculer la rotation pour orienter le projectile vers la direction calculée
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Appliquer la rotation au projectile
            projectile.transform.rotation = rotation;

            // Récupérer le Rigidbody du projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Appliquer la vélocité dans la direction calculée, avec la vitesse du projectile
                rb.velocity = direction * 10f; // 10f est la vitesse du projectile, ajustez selon vos besoins
            }
            else
            {
                Debug.LogError("Rigidbody not found on Projectile prefab!");
            }
        }
        else
        {
            Debug.LogError("Missing projectilePrefab, firePoint or target reference!");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTakeDamage player = other.GetComponent<PlayerTakeDamage>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            enemyAnimator.SetBool("mort", true); // Déclencher l'animation de mort

            // Ajouter l'instanciation de l'objet d'expérience
            if (xpPrefab != null)
            {
                Instantiate(xpPrefab, transform.position, Quaternion.identity);
            }

            // Ajouter l'instanciation de l'objet de pièces
            if (coinsPrefab != null)
            {
                Instantiate(coinsPrefab, transform.position, Quaternion.identity);
            }

            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1f); // Attendre 1 seconde
        Destroy(gameObject); // Détruire l'objet ennemi
    }
}
