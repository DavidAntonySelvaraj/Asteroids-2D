using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField]
    private WeaponUpgrades weaponUpgrade;

    private CollectableScript collectableScript;

    void DestroyCollectable(CollectableScript coll)
    {
        if(coll.type !=collectableType.defence)
            Destroy(coll.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectableScript = collision.GetComponent<CollectableScript>();

            if (collectableScript.type == collectableType.blaster)
            {
                weaponUpgrade.DeactivateWeapon(0);
                weaponUpgrade.DeactivateWeapon(1);
                weaponUpgrade.DeactivateWeapon(2);
                weaponUpgrade.ActivateWeapon(3);

                Invoke("ActivateBaseWeapon", 10f);
            }

            DestroyCollectable(collectableScript);

        }
    }

    void ActivateBaseWeapon()
    {

        //Debug.Log("CHANGED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
        weaponUpgrade.ActivateWeapon(0);
        weaponUpgrade.ActivateWeapon(1);
        weaponUpgrade.ActivateWeapon(2);
        weaponUpgrade.DeactivateWeapon(3);
    }


}//class





























































































