using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject zombi;
    public Transform spawnZombi;
    private float fireRate = 5f;
    private float nextFite = 5f;
    public int i = 4;
    void Update()
    {
        if (Time.time > nextFite && i >= 0)
        {
            nextFite = Time.time + fireRate;
            Instantiate(zombi, spawnZombi.position, spawnZombi.rotation);
            i--;
        }
    }
}
