using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{

    float maxSpeed = 10;
    public float acceleration = 5; //How fast we accelerate
    public float deacceleration = 4; //brake power
   
    bool isGrounded;
    Rigidbody2D rb;

    Vector2 velocity;
    Vector2 pos;
    Vector2 rawInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
        
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            
            rb.AddForce(new Vector2(rb.velocity.x, 5), ForceMode2D.Impulse);

            Debug.Log("Space was pressed");
            isGrounded=false;
        }

        //Get the raw input
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        if (rawInput.x != 0) 
        {
            Debug.Log("x");
            velocity.x += rawInput.x * 5 * Time.deltaTime;
            
            rb.velocity = new Vector2(velocity.x, rb.velocity.y);
            


        }
        else
        {
            velocity.x = 0;
        }
        

        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
            velocity.Normalize();
        }


        if (velocity.x > maxSpeed)
        {
            
            velocity.x = maxSpeed;
            
        }

        if (rawInput.sqrMagnitude == 0)
        {
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

    }
}
