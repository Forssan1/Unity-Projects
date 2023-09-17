using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Public variables that wer can edit in the editor
    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
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


    Rigidbody2D rb20;

    private void Start()
    {
        rb20 = GetComponent<Rigidbody2D>();

        
    }



    void Update()
    {
        velocity.Normalize();
        //Get the raw input
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }


        velocity += rawInput * acceleration * Time.deltaTime;

 
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {

            velocity.Normalize();
            velocity *= maxSpeed;
        }

        //If we have zero input from the player
        if (rawInput.sqrMagnitude == 0)
        {

            velocity *= 1 - deacceleration * Time.deltaTime;
        }

        position += velocity * Time.deltaTime;
        

        rb20.velocity = velocity;
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
