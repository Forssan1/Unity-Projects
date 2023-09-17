using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Public variables that wer can edit in the editor
    public float maxSpeed = 29; //Our max speed
    public float acceleration = 5; //How fast we accelerate
    public float deacceleration = 4; //brake power
    int points = 0;
    public GameObject Coin;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    int x = 0;
    int y = 0;
    //Private variables for internal logic
    Vector2 rawInput; //raw input values from the player
    Vector2 velocity; //Our current velocity
    Vector2 position; //our position



    private void Start()
    {
        

        
    }



    void Update()
    {
        //Get the raw input
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        //If we have a square magnitude over one, normalize the length of the vector to 1
        //if it's shorter then one we don't need this step.
        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }

        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocity += rawInput * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            //Normalize our velocity and change the magnitude to our max speed.
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        //If we have zero input from the player
        if (rawInput.sqrMagnitude == 0)
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocity *= 1 - deacceleration * Time.deltaTime;
        }

        //Update our position vector with our movement over time
        position += velocity * Time.deltaTime;

        //Move our transform based to our updated position.
        transform.position = position;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            points+= 1;

            x = Random.Range(-9,9);
            y = Random.Range(-9, 9);


            Instantiate(Coin, new Vector2(x/2, y/2), transform.rotation);
            Instantiate(Coin, new Vector2(x, y), transform.rotation);
            //Instantiate(collision.gameObject, new Vector2(x, y), transform.rotation);
            Destroy(collision.gameObject);

            textMeshProUGUI.text = "Points: " + points;
            
            
        }
    }
}
