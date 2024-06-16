using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    public PlayerWeapon weapon;
    
    [SerializeField]
    private Camera cam;
    
    [SerializeField]
    private LayerMask mask;
    
    [SerializeField]
    private GameObject bulletPrefab; // Référence à la prefab de balle
    [SerializeField]
    private Transform bulletSpawn; // Position de spawn de la balle

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Pas de caméra renseignée sur le système de tir.");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    private void Shoot()
    {
        CmdShoot();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            if(hit.collider.tag == "Player")
            {
                CmdPlayerShot(hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    private void CmdShoot()
    {
        RpcShoot();
    }

    [ClientRpc]
    private void RpcShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * weapon.bulletSpeed;
        NetworkServer.Spawn(bullet);
    }

    [Command]
    private void CmdPlayerShot(string playerId, float damage)
    {
        Debug.Log(playerId + " a été touché.");
        PlayerMulti player = GameManager.GetPlayer(playerId);
        player.RpcTakeDamage(damage);
    }
}