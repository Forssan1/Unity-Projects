using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweekExample : MonoBehaviour
{
    public float x;
    public float y;
    public float diameter = 0.2f;

    void Update()
    {
        transform.position = new Vector3(x, y);
        transform.localScale = new Vector3(diameter, diameter, diameter);
    }
}