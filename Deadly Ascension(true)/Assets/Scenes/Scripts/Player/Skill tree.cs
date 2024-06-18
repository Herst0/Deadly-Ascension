using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class SkillTree : MonoBehaviour
{
    PlayerTakeDamage playerTakeDamage;
    ThirdPersonController thirdPersonController;

    void Awake()
    {
        playerTakeDamage = GetComponent<PlayerTakeDamage>();
        thirdPersonController = GetComponent<ThirdPersonController>();
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

    public void SpeedUp()
    {
        thirdPersonController.MoveSpeed += 0.5f; // Augmenter la vitesse de déplacement de 0.5
    }
}