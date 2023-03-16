using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject meteors;

    [SerializeField]
    private float minX, maxX;

    private float minSpawmInterval = 1f, maxSpawmInterval = 1f;

    private int SpawnNum = 1;

    private Vector3 randSpawnPos;


    private void Start()
    {

        Invoke("SpawnMeteor",Random.Range(minSpawmInterval, maxSpawmInterval));
        
    }

    

    void SpawnMeteor()
    {
        int totalSpawnNum = 0;
        totalSpawnNum++;
        SpawnNum = Random.Range(1, totalSpawnNum);
        

        for (int i = 0; i < SpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors, randSpawnPos, Quaternion.identity);
            

            
        }
      
        Invoke("SpawnMeteor", Random.Range(minSpawmInterval, maxSpawmInterval));
        SpawnNum = SpawnNum++;
    }
   





}//class












