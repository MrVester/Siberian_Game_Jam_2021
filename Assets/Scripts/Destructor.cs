using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Trash")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
        }
    }
}
