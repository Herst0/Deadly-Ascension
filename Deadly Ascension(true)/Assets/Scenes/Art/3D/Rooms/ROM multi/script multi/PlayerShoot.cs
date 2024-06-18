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
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
      //  weaponManager.GetCurrentGraphics().muzzleFlash.Play();
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
        }
    
    }

    [Command]
    private void CmdPlayerShot(string playerId, float damage)
    {
        Debug.Log(playerId + " a été touché.");
        PlayerMulti player = GameManager.GetPlayer(playerId);
        player.RcpTakeDamage(damage);

    }

}