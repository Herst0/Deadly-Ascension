using System;
using Mirror;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private void Start()
    {
        if (!isLocalPlayer)
        {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                 componentsToDisable[i].enabled = false;
            }
            
        }
        else
        {
            Camera.main.gameObject.SetActive(false);
        }
=======
>>>>>>> Stashed changes
             for (int i = 0; i < componentsToDisable.Length; i++)
             {
                componentsToDisable[i].enabled = false;
            }
            
        }
<<<<<<< Updated upstream
=======
>>>>>>> 152a1be6fe9b4796a24c82db8a820e109e3a0b27
>>>>>>> Stashed changes
    }
}
