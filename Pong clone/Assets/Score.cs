using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Score : MonoBehaviour
{

    private int P1_score;
    private int P2_score;



    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "WallLeft")
        {
            P1_score += 1;
            Debug.Log(P1_score);
        }

        if (col.gameObject.name == "WallRight")
        {
            P2_score += 1;
            Debug.Log(P2_score);
        }
    }
}
