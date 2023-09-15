using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3;

    public GameObject enemy;
    int x = 0;
    int y = 0;
    Transform target;
    Rigidbody2D rb20;

    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb20 = GetComponent<Rigidbody2D>();
 
    }




    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;

        direction.Normalize();

        rb20.velocity = direction * speed;


        transform.up = -direction;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Laser>() != null)
        {
            x = Random.Range(-20 , 20);
            y = Random.Range(-20, 20);



            Instantiate(enemy, new Vector2(x, y), transform.rotation);
            Instantiate(enemy, new Vector2(x, y), transform.rotation);

            
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }


}
