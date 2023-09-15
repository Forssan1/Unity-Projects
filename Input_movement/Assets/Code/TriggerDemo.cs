using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDemo : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Trigger happy!" + other.gameObject.name);



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

}
