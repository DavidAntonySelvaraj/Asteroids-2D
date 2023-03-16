using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject meteors;

    [SerializeField]
    private float minY, maxY;

    private float minSpawmInterval = 1f, maxSpawmInterval = 1f;

    private int SpawnNum = 1;

    private Vector3 randSpawnPos;

    public Action onSpaceInput;


    private void Start()
    {

        onSpaceInput = () =>
        {
            Invoke("SpawnMeteor", 2f);
            onSpaceInput = null;
        };
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            onSpaceInput?.Invoke();
        }
    }


    void SpawnMeteor()
    {
        int totalSpawnNum = 0;
        totalSpawnNum++;
        SpawnNum = Random.Range(1, totalSpawnNum);
        

        for (int i = 0; i < SpawnNum; i++)
        {
            randSpawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);
            Instantiate(meteors, randSpawnPos, Quaternion.identity);
            

            
        }
      
        Invoke("SpawnMeteor", Random.Range(minSpawmInterval, maxSpawmInterval));
        SpawnNum = SpawnNum++;
    }
   





}//class












