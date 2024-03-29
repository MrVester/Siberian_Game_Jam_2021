﻿using System.Collections;
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
    private Rigidbody2D objectRB;
    public float minObjectForce=0f;
    public float maxObjectForce=3f;

    GameWon_Lost gamewon_lost;
   


    void Start()
    {
     
        gamewon_lost = GameWon_Lost.instance;
       
            spawnPosY = spawnZone.bounds.center.y;
    }


    void Update()
    {


        if (!gamewon_lost.GameEnded)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                spawnPosX = Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x);
                GameObject obj = (GameObject)Instantiate(FallingObjects[Random.Range(0, FallingObjects.Length)], new Vector3(spawnPosX, spawnPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                objectRB = obj.GetComponent<Rigidbody2D>();
                float randomRangeForce = Random.Range(minObjectForce, maxObjectForce) * 0.01f;
                objectRB.AddForce(-Vector2.up * randomRangeForce);
                Debug.Log(randomRangeForce);
            }
        }
    }
}
