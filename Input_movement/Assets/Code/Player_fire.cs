using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_fire : MonoBehaviour
{

    public GameObject laserPrefab;
    float timer;
    float fireRate = 0.1f;
    public Transform gun1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        transform.up = direction;

        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            //Instantiate(gameObject, transform.position, transform.rotation);
            //Instantiate(gameObject, transform.position, transform.rotation);

            timer = 0;
            Instantiate(laserPrefab, gun1.position, transform.rotation);
            
        }

        timer += Time.deltaTime;
    }
}
