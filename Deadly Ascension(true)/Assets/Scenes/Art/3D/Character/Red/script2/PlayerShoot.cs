using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    public PlayerWeapon weapon;

    void Start()
    {
        // Vérifiez si nécessaire la caméra et autres conditions
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            CmdShoot();
        }
    }

    [Command]
    private void CmdShoot()
    {
        // Instantiate the bullet on the server side
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Apply any specific settings or damage to the bullet (if needed)
        BulletProjectile bulletScript = bullet.GetComponent<BulletProjectile>();
        bulletScript.SetDamage(weapon.damage); // Set damage based on weapon stats

        // Spawn the bullet for connected clients
        NetworkServer.Spawn(bullet);
    }
}