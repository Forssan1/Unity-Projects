using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Demo : ProcessingLite.GP21
{
    //public float diameter = 2;
    //public Vector2 CirclePosition;
    //private Vector2 distance;
    //public float variable = 0.05f;

    //void Start()
    //{

    //    Application.targetFrameRate = 60;

    //}

    //void Update()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        variable = 0.05f;
    //        Vector2 mousePos = new Vector2(MouseX, MouseY);
    //        distance = (mousePos) - (CirclePosition);
    //    }


    //    CirclePosition += distance * variable;
    //    Debug.Log(distance);

    //    if (CirclePosition.x < 0)
    //    {
    //        CirclePosition += new Vector2(0.1f, 0);
    //        if (variable == 0.05f)
    //        {
    //            variable = -0.05f;
    //        }

    //        else
    //        {
    //            variable = 0.05f;
    //        }
    //        distance.y = -distance.y;
    //    }

    //    if (CirclePosition.x > Width)
    //    {
    //        CirclePosition += new Vector2(-0.1f, 0);
    //        if (variable == -0.05f)
    //        {
    //            variable = 0.05f;
    //        }

    //        else
    //        {
    //            variable = -0.05f;
    //        }
    //        distance.y = -distance.y;
    //    }




    //    if (CirclePosition.y < 0)
    //    {
    //        CirclePosition += new Vector2(0, 0.1f);
    //        if (variable == 0.05f)
    //        {
    //            variable = -0.05f;
    //        }

    //        else
    //        {
    //            variable = 0.05f;
    //        }
    //        distance.x = -distance.x;
    //    }

    //    if (CirclePosition.y > Height)
    //    {
    //        CirclePosition += new Vector2(0, -0.1f);
    //        if (variable == -0.05f)
    //        {
    //            variable = 0.05f;
    //        }

    //        else
    //        {
    //            variable = -0.05f;
    //        }
    //        distance.x = -distance.x;
    //    }


    //    Background(0);
    //    Circle(CirclePosition.x, CirclePosition.y, diameter);
    //    Line(CirclePosition.x, CirclePosition.y, MouseX, MouseY);





    //}



    Vector2 circlePosition;
    Vector2 circleVelocity;
    float maxSpeed = 0.05f;


    void Start()
    {
        
        circlePosition = new Vector2 (Width / 2, Height / 2);
    }

    void Update()
    {

        Background(128);
        
        if(Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX; 
            circlePosition.y = MouseY;
            circleVelocity = Vector2.zero;
        }

        if(Input.GetMouseButton(0)) 
        { 
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
        }

        if (Input.GetMouseButtonUp(0))
        {
            circleVelocity =((new Vector2(MouseX, MouseY) - circlePosition) * 0.01f);

            if (circleVelocity.magnitude > maxSpeed)
            {
                circleVelocity.Normalize();
                circleVelocity *= maxSpeed;
            }

        }

        if (circlePosition.x > Width || circlePosition.x < 0)
        {
            circleVelocity.x *= -1;
        }
        if (circlePosition.y > Height || circlePosition.y < 0)
        {
            circleVelocity.y *= -1;
        }

        circlePosition += circleVelocity;

        Circle(circlePosition.x, circlePosition.y, 1);
    }
}
