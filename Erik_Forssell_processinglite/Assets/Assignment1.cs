using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Assignment1 : ProcessingLite.GP21
{

    public float spaceBetweenLines = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Width);

    }

    // Update is called once per frame

    float frame = 0;
    void Update()
    {
        //Clear background
        Background(0,0,0);

        Stroke(255, 255, 255);
        StrokeWeight(3);


        //Ellipse(8, 5, 16, 10);


        Line(4, 8, 4, 2);
        Line(4, 8, 7, 8);
        Line(4, 5, 7, 5);
        Line(4, 2, 7, 2);

        Line(10, 8, 10, 2);
        Line(10, 8, 13, 8);
        Line(10, 5, 13, 5);




        Stroke(128, 128, 128, 64);
        StrokeWeight(0.5f);

        frame+= 0.002f;

        for (int i = -5; i < Height / spaceBetweenLines; i++)
        {

            //Increase y-cord each time loop run
            float y = i * spaceBetweenLines;
            
            //Draw a line from left side of screen to the right
            Line(0, y + frame%1.2f, Width, y + frame % 1.2f);
        }




        int x = 0;
        int color = 0;

        
        for (float i = 0; i < 20; i+=0.1f)
        {


            //Debug.Log(i);

            color = (int)(i % 3);

           



            if (x == color)
            {
                Stroke(128, 128, 128, 64);
                
            }

            else 
            {
                Stroke(255, 0, 0);

            }
            
            Line(0, Height/2 - i, i, 0);
            Line(Width, Height/2 - i, Width-i, 0);
            x = color;
            
        }
    }
}
