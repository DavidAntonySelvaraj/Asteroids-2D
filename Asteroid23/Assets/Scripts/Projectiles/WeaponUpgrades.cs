using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : MonoBehaviour
{
    [SerializeField]
    private projectile[] weapons;

    public void ActivateWeapon(int weaponIndex)
    {
        weapons[weaponIndex].enabled = true;
    }

    public void DeactivateWeapon(int weaponIndex)
    {
        weapons[weaponIndex].enabled = false;
    }




}//class




















