using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum collectableType
{
    blaster,defence
};



public class CollectableScript : MonoBehaviour
{
    public collectableType type;

    [SerializeField]
    private float moveSpeed= 5f;

    private Vector3 tempPos;

    [HideInInspector]
    public float healthValue;

    public bool isDefence;

    private SpriteRenderer sr;


    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG) && type == collectableType.defence)
        {

            isDefence = true;
            Invoke("SetIsDefence", 10f);
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==TagManager.PLAYER_TAG && type == collectable.defence)
        {
            sr.enabled = false;
            isDefence = true;
            Invoke("SetIsDefence", 10f);
        }
    }*/

    /*void SetIsDefence()
    {
        Destroy(gameObject);
        isDefence = false;
    }


    public bool ChackIfDefended()
    {
        return isDefence;
    }*/
}//class


















