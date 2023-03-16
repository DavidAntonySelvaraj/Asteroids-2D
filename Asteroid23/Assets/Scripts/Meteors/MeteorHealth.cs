using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHealth : MonoBehaviour
{


    [SerializeField]
    private float health = 20f;

    [SerializeField]
    private bool BigMeteor;

    [SerializeField] private List<GameObject> smallMeteor = new List<GameObject>();

    [SerializeField]
    private Transform spawnSmallMeteor;


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            //gameObject.SetActive(false);
            CheckIfSmallOrLargeMeteor();
            //Destroy(gameObject);
            
            
        }
        else
        {

        }

    }

    void CheckIfSmallOrLargeMeteor()
    {
        if (BigMeteor)
        {
            Destroy(gameObject);
            for (int i = 0; i < smallMeteor.Count; i++)
            {
                Instantiate(smallMeteor[i], spawnSmallMeteor.position, Quaternion.identity);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

   



}//class

















