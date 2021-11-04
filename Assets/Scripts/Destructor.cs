using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Object")
        {
            Destroy(collision.gameObject);
        }
    }
}
