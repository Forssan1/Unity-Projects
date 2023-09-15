using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{


    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 10 * Time.deltaTime;

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(newExplosion, 1);
        Destroy(gameObject);
    }
}
