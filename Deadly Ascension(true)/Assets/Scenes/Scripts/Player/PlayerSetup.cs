using System;
using Mirror;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;
    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer(); //le mettre sur les ennemy
        }

        RegisterPlayer();
    }

    private void RegisterPlayer()
    {
        //change nom du joueur par un identifiant unique -> plus simple à identifier
        string playername =  "Player"+GetComponent<NetworkIdentity>().netId;
        transform.name = playername;
    }
    
    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
    private void DisableComponents()
    {
        // On va boucler sur les différents composants renseignés et les désactiver si ce joueur n'est pas le notre
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
    
    
}
