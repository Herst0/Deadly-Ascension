using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerTakeDamage : NetworkBehaviour
{
    [SyncVar] private float health;
    [SerializeField] private float maxHealth = 20f;

    public override void OnStartServer()
    {
        health = maxHealth;
    }

    [Server]
    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage called with damage: " + damage);
        health -= damage;
        if (health <= 0)
        {
            RpcHandleDeath();
            // Ajouter animation de mort
        }
    }

    [ClientRpc]
    void RpcHandleDeath()
    {
        Debug.Log("RpcHandleDeath called, destroying player.");
        Destroy(gameObject);
    }
    public void TakeDamage(int amount)
    {
        if (!isServer) return;  // Seul le serveur gère les dégâts

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}