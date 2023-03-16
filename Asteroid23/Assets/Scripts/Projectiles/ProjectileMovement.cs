using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{


    [SerializeField] private float speed = 3f;

    private float Damage = 10;


    private void Update()
    {

        transform.localPosition+=transform.up*speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.METEOR_TAG))
        {
            Debug.Log("Hit");
            collision.GetComponent<MeteorHealth>().TakeDamage(Damage);
        }
    }

}//class













