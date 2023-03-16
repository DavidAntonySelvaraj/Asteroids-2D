using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float rotationSpeed = 100.0f;

    private float moveVectorH;
    private float moveVectorV;


    private Rigidbody2D playerRb;

   

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVectorH = Input.GetAxis("Horizontal");
        moveVectorV = Input.GetAxis("Vertical");

        MoveForward();
        RotateSpaceShip();
    }

    void MoveForward()
    {
        playerRb.velocity = transform.up * moveVectorV * speed;
        if (moveVectorV < 0)
        {
            playerRb.velocity = new Vector2 (0, 0);
        }
    }

    void RotateSpaceShip()
    {
        transform.Rotate(0, 0, -moveVectorH * rotationSpeed * Time.deltaTime);
    }

    

}//class











