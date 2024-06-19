using Player;
using StarterAssets;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public float health, maxHealth = 20f;
    public float defence = 1f;

    private Animator animator;
    private ThirdPersonController thirdPersonController;
    private ThirdPersonShooter thirdPersonShooter;
    private bool isDead = false;

    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        thirdPersonShooter = GetComponent<ThirdPersonShooter>();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; // Prevent taking damage if already dead

        health -= damage / defence;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("mort", true);

        // Disable player controls
        thirdPersonController.enabled = false;
        thirdPersonShooter.enabled = false;
    }
}