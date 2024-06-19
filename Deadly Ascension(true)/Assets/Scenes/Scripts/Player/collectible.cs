using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public ManagerUi scoreManager;
	public PlayerTakeDamage player;
    void Start()
    {
        scoreManager = GameObject.Find("argent").GetComponent<ManagerUi>();
		player = GameObject.Find("Player").GetComponent<PlayerTakeDamage>();	
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
            else
            {
                if (gameObject.CompareTag("MoneyP"))
                {
                    scoreManager.IncreaseMoney(1);
                }
                else
                {
                    scoreManager.IncreaseMoney(5);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
