using System;
using Mirror;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private void Start()
    {
        // if (!isLocalPlayer)
        // {
        //     for (int i = 0; i < componentsToDisable.Length; i++)
        //     {
        //         componentsToDisable[i].enabled = false;
        //     }
        //     
        // }
    }
}
