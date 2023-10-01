using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numberOfBalls = 100; // Number of balls to create

    private List<Balls> ballsList = new List<Balls>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            CreateBall(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update ball positions
        foreach (var ball in ballsList)
        {
            ball.UpdatePos();
        }
    }

    void CreateBall(float x, float y)
    {
        GameObject newBall = Instantiate(ballPrefab, new Vector3(x, y, 0), Quaternion.identity);
        ballsList.Add(new Balls(newBall));
    }

    public class Balls
    {
        private GameObject ballObject;
        private Vector2 velocity; // Ball direction

        // Ball Constructor, called when we type new Ball(x, y);
        public Balls(GameObject ball)
        {
            ballObject = ball;
            // Create the velocity vector and give it a random direction.
            velocity = new Vector2
            {
                x = Random.Range(0, 11) - 5,
                y = Random.Range(0, 11) - 5
            };
        }

        // Update ball position
        public void UpdatePos()
        {
            Vector3 currentPosition = ballObject.transform.position;
            currentPosition += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
            ballObject.transform.position = currentPosition;
        }

    }
}
