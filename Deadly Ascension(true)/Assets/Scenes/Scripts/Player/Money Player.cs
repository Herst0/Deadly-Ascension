using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlayer : MonoBehaviour
{
	private int _moneyPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool verif = collectible.OnTriggerEnter(Collider other);
		if(verif)
		{
			_moneyPlayer += 1;	
		}
    }
}
