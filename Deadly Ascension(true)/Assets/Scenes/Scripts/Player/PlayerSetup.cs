using System;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private Camera sceneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            //on boucle sur les différents composants du joueur pour les désactiver (si il n'est pas le notre) ça évite de contrôler deux joueurs en même temsp
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
  
    }
}
