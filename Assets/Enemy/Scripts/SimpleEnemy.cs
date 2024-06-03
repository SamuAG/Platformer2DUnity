using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    Rigidbody2D rb;
    
    int currentDirection = -1;
    float remainingIdleTime = 2;
    [SerializeField] float idleTime = 2;
    float remainingTimeToChangeDirection = 2;
    [SerializeField] float timeToChangeDirection = 2;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        remainingIdleTime -= Time.deltaTime;
        if (remainingIdleTime <= 0)
        {
            remainingTimeToChangeDirection -= Time.deltaTime;

            if (remainingTimeToChangeDirection <= 0)
            {
                remainingIdleTime = Random.Range(0, idleTime);
                currentDirection *= -1;
                remainingTimeToChangeDirection = Random.Range(0, timeToChangeDirection);
            }

            canMove = true;
            
        }
        else
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if(canMove) Move();
    }

    override protected void Move()
    {
        rb.velocity = new Vector2(currentDirection * speed, rb.velocity.y);
    }
}
