using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public ManagerUi scoreManager;
    public PlayerTakeDamage player;
    public BulletTarget bulletTarget; // Référence au script BulletTarget

    void Start()
    {
        scoreManager = GameObject.Find("argent").GetComponent<ManagerUi>();
        player = GameObject.Find("Player").GetComponent<PlayerTakeDamage>();
        bulletTarget = GameObject.Find("Player").GetComponent<BulletTarget>(); // Assurez-vous que BulletTarget est sur le joueur ou modifiez cette ligne pour obtenir le bon objet
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ADN"))
            {
                scoreManager.IncreaseADN();
            }
            else if (gameObject.CompareTag("Soin"))
            {
                player.health = 20;
            }
            else if (gameObject.CompareTag("MoneyP"))
            {
                scoreManager.IncreaseMoney(1);
            }
            else if (gameObject.CompareTag("Money"))
            {
                scoreManager.IncreaseMoney(5);
            }
            else if (gameObject.CompareTag("Strong"))
            {
                bulletTarget.damageAmount += 1; // Change the damage amount
                Debug.Log("Bullet damage increased to 2");
            }

            gameObject.SetActive(false);
        }
    }
}