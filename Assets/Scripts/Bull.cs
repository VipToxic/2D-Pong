using UnityEngine;

public class Bull : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;

    void Start()
    {
        LaunchBall();
    }

    public void LaunchBall()
    {
        bool isRight = Random.value >= 0.5f;

        float xVelocity = -1f;

        if (isRight)
        {
            xVelocity = 1f;
        }

        float yVelocity = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(
            xVelocity * startingSpeed,
            yVelocity * startingSpeed
        );
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;

        LaunchBall();
    }
}