using Player;
using StarterAssets;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerTakeDamage : MonoBehaviour
{
    public float health, maxHealth = 20f;
    public float defence = 1f;

    private Animator animator;
    private ThirdPersonController thirdPersonController;
    private ThirdPersonShooter thirdPersonShooter;
    private bool isDead = false;
    
    public Transform player, destination;
    public GameObject playerg;
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        thirdPersonShooter = GetComponent<ThirdPersonShooter>();
        
        animator.SetBool("mort", false);
        
        playerg.SetActive(false);
        player.position = destination.position;
        playerg.SetActive(true);
        
       
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
    
    private async Task respawn()
    {
        await Task.Delay(4000);
        thirdPersonController.enabled = true;
        thirdPersonShooter.enabled = true;
        isDead = false;
        
       
       
        Start();
        
    }

    private void Die()      
    {
        isDead = true;
        animator.SetBool("mort", true);

        // Disable player controls
        thirdPersonController.enabled = false;
        thirdPersonShooter.enabled = false;
        
        
        respawn();
    }


}