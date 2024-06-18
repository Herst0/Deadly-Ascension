using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] public float heath, maxHealth = 20f;

    public void Start()
    {
        heath = maxHealth;
    }
    

    public void TakeDamage(float damage)
    {
        heath -= damage;
        if (heath <= 0)
        {
            Destroy(gameObject);
            //mort du perso à intégrer
        }
    }


}