using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{



    [SerializeField] private GameObject projectileGb;

    [SerializeField]
    private List<GameObject> projectilePool = new List<GameObject>();

    [SerializeField]
    private GameObject projectileHolder;

    [SerializeField]
    private KeyCode KeyToPressToShoot;

    private bool projectileSpawned;

    [SerializeField]
    private Transform projectileSpawnedPoint;

    [SerializeField]
    private float shootWaitTime;

    private float shootTimer;

    private bool canShoot;

    [SerializeField]
    private bool isEnemy;


    private void Awake()
    {
        projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
    }

    private void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true;

        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {
        if (!canShoot)
            return;

        if (Input.GetKeyDown(KeyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetShootingTimer();
        }
    }

    void GetObjectFromPoolOrSpawnANewOne()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnedPoint.position;
                projectilePool[i].transform.rotation = projectileSpawnedPoint.rotation;
                projectilePool[i].SetActive(true);

                projectileSpawned = true;

                break;
            }
            else
            {
                projectileSpawned = false;
            }
        }
        if (!projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectileGb, projectileSpawnedPoint.position,Quaternion.identity);
            projectilePool.Add(newProjectile);

            newProjectile.transform.SetParent(projectileHolder.transform);
            newProjectile.transform.rotation = projectileSpawnedPoint.rotation;

            projectileSpawned = true;
        }
    }

    void ResetShootingTimer()
    {
        canShoot = false;

        shootTimer = Time.time + shootWaitTime;
    }
    

}//class





