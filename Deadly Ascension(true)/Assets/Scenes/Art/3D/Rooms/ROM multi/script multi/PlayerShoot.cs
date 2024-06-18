using UnityEngine;
using Mirror;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour
{
    public PlayerWeapon currentweapon;
    [SerializeField]
    private Camera cam;

    private WeaponManager weaponManager;
    
    [SerializeField] private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Pas de caméra renseignée sur le système de tir.");
            this.enabled = false;
        }

        weaponManager = GetComponent<WeaponManager>();
    }
    void Update()
    {
        currentweapon = weaponManager.GetCurrentWeapon();
        if (currentweapon.fireRate<=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot",0f,1f/currentweapon.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }
    [Command]
    void CmdOnShoot()
    {
        RpcDoShootEffect();
    }
    [ClientRpc]
    void RpcDoShootEffect()
    {
       weaponManager.GetCurrentGraphics().muzzleFlash.Play();
    }

    [Client]
    private void Shoot()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        CmdOnShoot();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, currentweapon.range, mask))
        {
            Debug.Log("Objet touch"+hit.collider.name);
            if(hit.collider.tag == "Player")
            {
                CmdPlayerShot(hit.collider.name, currentweapon.damage);
            }
            CmdOnHit(hit.point, hit.normal);
        }
    
    }
    [Command]
    void CmdOnHit(Vector3 pos, Vector3 normal)
    {
        RpcDoHitEffect(pos, normal);
    }
    [ClientRpc]
    void RpcDoHitEffect(Vector3 pos, Vector3 normal)
    {
        GameObject hitEffect = Instantiate(weaponManager.GetCurrentGraphics().hitEffectPrefab, pos, Quaternion.LookRotation(normal));
        Destroy(hitEffect, 2f);
    }


    [Command]
    private void CmdPlayerShot(string playerId, float damage)
    {
        Debug.Log(playerId + " a été touché.");
        PlayerMulti player = GameManager.GetPlayer(playerId);
        player.RpcTakeDamage(damage);

    }

}