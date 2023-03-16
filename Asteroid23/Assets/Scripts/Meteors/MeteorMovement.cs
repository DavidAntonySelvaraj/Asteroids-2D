using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteorMovement : MonoBehaviour
{


    [SerializeField] private float minSpeed = 4f, maxSpeed = 10f;

    private float speedX, speedY;

    [SerializeField]
    private bool moveOnX,moveOnY;

    [SerializeField] private float minRotationalSpeed = 15f, maxRotationalSpeed = 50f;

    private float rotationalSpeed;

    private Vector3 tempMovement;

    private float zRotation;

    private void Awake()
    {
        rotationalSpeed = Random.Range(minRotationalSpeed,maxRotationalSpeed);

        speedX = Random.Range(minSpeed,maxSpeed);
        speedY = speedX;

        
            speedX *= -1f;
      

        if (Random.Range(0, 2) > 0)
        {
            rotationalSpeed *= -1f;
        }


        moveOnX = true;

    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();
        RotateMeteor();
    }

    void HandleMovementX()
    {
        if(!moveOnX)
            return;

        tempMovement = transform.position;
        tempMovement.x+=speedX*Time.deltaTime;
        transform.position = tempMovement;
    }

    void HandleMovementY()
    {
        if (!moveOnY)
            return;

        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }
    void RotateMeteor()
    {
        zRotation += rotationalSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }

}//class












































