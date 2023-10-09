using UnityEngine;

//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Public variables that wer can edit in the editor
    public float maxSpeed = 8; //Our max speed
    public float acceleration = 40; //How fast we accelerate
    public float deacceleration = 10; //brake power
    public float jumpPower = 8;
    float velocityX; //Our current velocity
    bool onGround = true;
    float groundCheckLenght;
    public float groundCheckDistance = 0.1f;

    Rigidbody2D rb2D; //Ref to our rigidbody

    private void Start()
    {
        //assign our ref.
        rb2D = GetComponent<Rigidbody2D>();
        var collider = GetComponent<Collider2D>();
        groundCheckLenght = collider.bounds.size.y + groundCheckDistance;
    }

    void Update()
    {
        XMovement();

        if (Input.GetButtonDown("Jump") && onGround)
        {
            Physics2D.queriesStartInColliders = false;
            rb2D.velocity = new Vector2 (rb2D.velocity.x, jumpPower);
        }


        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            Physics2D.queriesStartInColliders = false;
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.25f);
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLenght);


        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = 4;
        }
        else
        {
            rb2D.gravityScale = 1;
        }
    }

    private void XMovement()
    {
        //Get the raw input
        float x = Input.GetAxisRaw("Horizontal");


        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocityX += x * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        //If we have zero input from the player
        if (x == 0 || (x < 0 == velocityX > 0))
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }


        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }
}