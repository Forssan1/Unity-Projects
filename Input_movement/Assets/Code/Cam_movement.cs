using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float speed;
    void Start()
    {
     
    }

    void FixedUpdate()
    {
        Vector3 DesiredPos = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, -10);
        transform.position = Vector3.Lerp(transform.position, DesiredPos, speed * Time.fixedDeltaTime);
    }
}