using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private PlayerTakeDamage player;
    
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = GameObject.Find("Player").GetComponent<PlayerTakeDamage>();
            player._money += 1;
            Debug.Log(player._money);
            Destroy(other);
        }

    }
}
