using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using StarterAssets;

public class SkillTree : MonoBehaviour
{
    
    PlayerTakeDamage playerTakeDamage;
    BulletTarget bulletTarget;

    void Awake()
    {
        playerTakeDamage = GetComponent<PlayerTakeDamage>();
        bulletTarget = GetComponent<BulletTarget>();

    }

    public void DmgUp()
    {
        bulletTarget.damageAmount += 1;
    }

    public void HealthUp()
    {
        playerTakeDamage.maxHealth += 5;
        playerTakeDamage.health += 5 ; // Optionnel : réinitialiser la santé actuelle
    }
}