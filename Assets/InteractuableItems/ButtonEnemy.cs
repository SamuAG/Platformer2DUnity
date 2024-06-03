using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemy : Enemy
{
    Rigidbody2D rb;

    int currentDirection = -1;
    [SerializeField] bool canMove = true;
    [SerializeField] float buttonDistance = 0.1f;
    GameObject[] buttons;
    Transform targetButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        buttons = GameObject.FindGameObjectsWithTag("Button");
        if (buttons.Length <= 0) Destroy(gameObject);
        targetButton = buttons[0].transform;
    }

    private void Update()
    {
        foreach (GameObject button in buttons)
        {
            if (Vector2.Distance(transform.position, button.transform.position) < Vector2.Distance(transform.position, targetButton.position))
            {
                targetButton = button.transform;
            }
        }
        
        if (targetButton == null) return;
        
        if (targetButton.position.x > transform.position.x)
        {
            currentDirection = 1;
        }
        else
        {
            currentDirection = -1;
        }

        // if the enemy is over the button, it will stop
        if (buttonDistance < Vector2.Distance(transform.position, targetButton.position))
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if (canMove) Move();
    }

    override protected void Move()
    {
        rb.velocity = new Vector2(currentDirection * speed, rb.velocity.y);
    }
}