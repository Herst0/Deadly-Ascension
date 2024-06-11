using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.XR;

public class Multi_Player : NetworkBehaviour
{
    private float speed = 5.0f;
    private float moveHori;
    private float moveVerti;
    private Vector3 _input;
    void HandleMovement()
    {
        if (isLocalPlayer) //verif pour éviter de toucher au déplacement de l'autre joueur
        {
            //récup les inputs du joueur
            float moveHori = Input.GetAxis("Horizontal"); 
            float moveVerti = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(
                Time.deltaTime * speed * moveHori,
                0,
                Time.deltaTime * speed * moveVerti);
            //nouvelle position du joueur
            transform.position += movement; //applique la nouvelle position

        }
    }

    private void Update() //run every frame
    {
        HandleMovement();
    }
}
