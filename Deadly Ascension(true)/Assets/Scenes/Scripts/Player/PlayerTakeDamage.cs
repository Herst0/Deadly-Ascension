using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
     public float health, maxHealth = 20f;
     public float defence = 1f;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage / defence;
        if (health <= 0)
        {
            Destroy(gameObject);
            //mort du perso à intégrer
        }
    }


}