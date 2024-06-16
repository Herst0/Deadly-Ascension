using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    private Camera sceneCamera;
    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }
        else
        {
            sceneCamera=Camera.main;
            if (sceneCamera!=null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
    
        }
        GetComponent<PlayerMulti>().Setup();



    }
    

    public override void OnStartClient()
    {
        base.OnStartClient();
        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerMulti player = GetComponent<PlayerMulti>();

        GameManager.RegisterPlayer(netId, player);
    }
    
    private void DisableComponents()
    {
        // On va boucler sur les différents composants renseignés et les désactiver si ce joueur n'est pas le notre
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
    
    private void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
    private void OnDisable()
    {
        if (sceneCamera!=null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnregisterPlayer(transform.name);

    }
}
