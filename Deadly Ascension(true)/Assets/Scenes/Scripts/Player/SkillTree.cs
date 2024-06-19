using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class SkillTree : MonoBehaviour
{
    PlayerTakeDamage playerTakeDamage;


    void Awake()
    {
        playerTakeDamage = GetComponent<PlayerTakeDamage>();
    }

    public void DefenceUp()
    {
        playerTakeDamage.defence += 0.3f;
    }

    public void HealthUp()
    {
        playerTakeDamage.maxHealth += 5f;
        playerTakeDamage.health = playerTakeDamage.maxHealth; // Optionnel : réinitialiser la santé actuelle
    }
}