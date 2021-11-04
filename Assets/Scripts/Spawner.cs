using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D spawnZone;
   public GameObject[] FallingObjects;
    private float spawnPosX;
    private float spawnPosY;
    [SerializeField]
    private float spawnRate = 3f;
    private float nextSpawn = 0.0f;
    void Start()
    {
        
        spawnPosY = spawnZone.bounds.center.y;
    }

 
    void Update()
    {

       
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnPosX = Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x);
            Instantiate(FallingObjects[Random.Range(0, FallingObjects.Length)], new Vector3(spawnPosX, spawnPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

}
