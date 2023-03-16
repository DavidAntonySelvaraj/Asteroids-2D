using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth = 100f;

    [SerializeField]
    private float playerHealth;

    private CollectableScript collectScript;

    private bool isProtected;


    private void Awake()
    {
        playerHealth = playerMaxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth-=damageAmount;

        if (playerHealth <= 0)
        {

            Destroy(gameObject);
        }
        else
        {
            //play damage sound
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectScript = collision.GetComponent<CollectableScript>();

            if (collectScript.type == collectableType.defence)
            {
                isProtected = true;
                Invoke("SetIsProtected", 10f);
                Destroy(collision.gameObject);

            }
        }



        if (collision.CompareTag(TagManager.METEOR_TAG) && isProtected == false )
        {
            TakeDamage(10f);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag(TagManager.METEOR_TAG) && isProtected == true)
        {
            TakeDamage(0f);
            Destroy(collision.gameObject);
        }

    }


    void SetIsProtected()
    {
        isProtected=false;
    }
}//class
































