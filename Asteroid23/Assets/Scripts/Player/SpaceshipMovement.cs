using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private SpaceShipMovementSO mShipMovementSO;

    [SerializeField]
    private CinemachineVirtualCamera mainVirtualCamera,tempVirtualCamera; 

    [SerializeField]
    private Transform startTransform;

    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float rotationSpeed = 100.0f;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    private float moveVectorH;
    private float moveVectorV;


    private Rigidbody2D playerRb;

    private bool inTransition;

    //pivate Cinemachine


    private void Start()
    {
        StartCoroutine(StartTransition());
    }


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.velocity = transform.right * mShipMovementSO.speed;
    }

    private void Update()
    {
        moveVectorH = Input.GetAxis("Horizontal");
        moveVectorV = Input.GetAxis("Vertical");

        MoveForward();
        RotateSpaceShip();
        HoldMovement();
    }



    void MoveForward()
    {
        playerRb.velocity = transform.up * moveVectorV * mShipMovementSO.speed;
        if (moveVectorV < 0)
        {
            playerRb.velocity = new Vector2 (0, 0);
        }
    }

    void RotateSpaceShip()
    {
        transform.Rotate(0, 0, -moveVectorH * mShipMovementSO.rotationSpeed * Time.deltaTime);
    }

    IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(2f);
        Vector3 dir = (startTransform.position - transform.position).normalized;

        while ((startTransform.position - transform.position).sqrMagnitude>=.2f)
        {
            transform.Translate(dir * mShipMovementSO.speed * Time.deltaTime);
            yield return null;
        }


        mainVirtualCamera.gameObject.SetActive(true);
        tempVirtualCamera.gameObject.SetActive(false);
    }

    void HoldMovement()
    {
        if (transform.position.x < minX)
            transform.position = new Vector3(minX, transform.position.y, 0f);

        if (transform.position.x > maxX)
            transform.position = new Vector3(maxX, transform.position.y, 0f);

        if (transform.position.y < minY)
            transform.position = new Vector3(transform.position.x, minY, 0f);

        if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, maxY, 0f);
    }

}//class











