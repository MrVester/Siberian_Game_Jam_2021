using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class Eraser : MonoBehaviour
{

    public PathCreator eraserPath;
    public float speed = 5f;
    float distanceTravelled;
    private float nextSpawn=0.0f;
    public float spawnRate = 0.1f;
    public GameObject maskPrefab;
    List<GameObject> eraserClonesList;
    public GameObject PersnBlueprint;
    public GameObject Panel;
    public GameObject Txt;

    private void Start()
    {
       
        eraserClonesList = new List<GameObject>();
    }
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Debug.Log(eraserPath.path.GetClosestTimeOnPath(transform.position));
        transform.position = eraserPath.path.GetPointAtDistance(distanceTravelled);
        if (eraserPath.path.GetClosestTimeOnPath(transform.position) >= 0.98f)//После стирания объектов выполнить далее:
        {
           
            Destroy(gameObject);
            PersnBlueprint.SetActive(false);
            Txt.SetActive(false);
            foreach (GameObject erClone in eraserClonesList)
            {
                GameObject.Destroy(erClone);
            }
            Panel.SetActive(true);
            

        }
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject eraserClone = (GameObject)Instantiate(maskPrefab, transform.position, transform.rotation);
            eraserClonesList.Add(eraserClone);
            
        }
        
    }
}
