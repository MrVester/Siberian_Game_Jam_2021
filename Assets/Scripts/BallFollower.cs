using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BallFollower : MonoBehaviour
{

    public PathCreator pathCreator;
    public float speed=5f;
    float distanceTravelled;
 
    void Update()
    {
       
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        if (pathCreator.path.GetClosestTimeOnPath(transform.position) >= 0.98f)
            Destroy(gameObject);
    }
}
