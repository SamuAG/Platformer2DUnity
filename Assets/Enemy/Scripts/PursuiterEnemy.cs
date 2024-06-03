using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuiterEnemy : Enemy
{
    Rigidbody2D rb;

    int currentDirection = -1;
    float remainingIdleTime = 2;
    [SerializeField] float idleTime = 2;
    float remainingTimeToChangeDirection = 2;
    [SerializeField] float timeToChangeDirection = 2;
    bool canMove = true;
    [SerializeField] float followDistance = 5;
    Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;
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
            if(followDistance > Vector2.Distance(transform.position, player.position))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            
        }
    }

    void FixedUpdate()
    {
        if (canMove) Move();
    }

    override protected void Move()
    {
        if (followDistance > Vector2.Distance(transform.position, player.position))
        {
            if (player.position.x > transform.position.x)
            {
                currentDirection = 1;
            }
            else
            {
                currentDirection = -1;
            }
        }
        rb.velocity = new Vector2(currentDirection * speed, rb.velocity.y);
    }
}