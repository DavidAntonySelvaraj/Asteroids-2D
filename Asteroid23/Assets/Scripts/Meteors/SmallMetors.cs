using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMetors : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Destroy(gameObject);
        }
    }
}//class











