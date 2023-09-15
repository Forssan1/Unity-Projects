using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Ball : MonoBehaviour
{



    private float speed = 80;
    public GameObject shake;
    private cameraShake cam;
    private int pointsL;
    private int pointsR;



    float hitFactor(Vector2 BallsPos, Vector2 RacketPos, float RacketHeight)
    {
        return (BallsPos.y - RacketPos.y) / RacketHeight;
    }

    [System.Obsolete]
    void Start()
    {
        
        StartCoroutine(StartTimer());
        cam = shake.GetComponent<cameraShake>();

    }

    [System.Obsolete]
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Player1") {

            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }


        if (col.gameObject.name == "Player2") {

            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);
            

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
  
        }

        if (col.gameObject.name == "WallRight" || col.gameObject.name == "WallLeft") 
        {
            
            //sets speed to 0 and stops the ball completely after hitting any wall
            speed = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            //shakes the camera when the ball hits either wall
            cam.shakeDuration = 0.2f;

            //starts timer + start over actions
            StartCoroutine(StartTimer());

        }




        if (col.gameObject.name == "WallTop" || col.gameObject.name == "WallBottom")
        {
            cam.shakeDuration = 0.2f;
        }




    }

    [System.Obsolete]
    IEnumerator StartTimer()
    {
        // after 2s makes the trail inactive and "restarts" ball
        yield return new WaitForSeconds(1);

        var trail = GameObject.Find("Trail");
        trail.active = false;
        
        
        transform.position = new Vector2(-2, 0);
        speed = 80;
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        trail.active = true;
        
    }
}

