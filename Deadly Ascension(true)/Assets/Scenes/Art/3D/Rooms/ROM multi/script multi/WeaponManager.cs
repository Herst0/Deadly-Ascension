using System;
using UnityEngine;
using Mirror;
using System.Collections;

public class WeaponManager : NetworkBehaviour
{

    [SerializeField] private PlayerWeapon primaryWeapon;
    [SerializeField] private string weaponLayerName = "Weapon";
    private PlayerWeapon currentWeapon;
    [SerializeField] private Transform weaponHolder;
    
    private void Start()
    {
        EquiWeapon(primaryWeapon);
    }

    void EquiWeapon(PlayerWeapon weapon)
    {
        currentWeapon = weapon;
        GameObject weaponIns = Instantiate(weapon.graphics, weaponHolder.position, weaponHolder.rotation);
        weaponIns.transform.SetParent(weaponHolder);

        if (!isLocalPlayer)
        {
            weaponIns.layer = LayerMask.NameToLayer(weaponLayerName);
        }
    }
   /* private WeaponGraphics currentGraphics;

   // [SerializeField] private Transform weaponHolder;
    //[SerializeField]
    private string weaponLayerName = "Weapon";
    void Start()
    {
        EquipWeapon(primaryWeapon);
    }*/

    public PlayerWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }
    /*
    public WeaponGraphics GetCurrentGraphics()
    {
        return currentGraphics;
    }

    public void EquipWeapon(PlayerWeapon _weapon)
    {
        currentWeapon = _weapon;

        GameObject weaponIns = Instantiate(_weapon.graphics, weaponHolder.position, weaponHolder.rotation);
        weaponIns.transform.SetParent(weaponHolder);
        
        currentGraphics = weaponIns.GetComponent<WeaponGraphics>();
        if(currentGraphics == null)
        {
            Debug.LogError("Pas de script WeaponGraphics sur l'arme : " + weaponIns.name);
        }
        if (isLocalPlayer)
        {
            Util.SetLayerRecursively(weaponIns, LayerMask.NameToLayer(weaponLayerName));
        }
    }*/


}
