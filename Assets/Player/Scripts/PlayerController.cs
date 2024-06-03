using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Componentes del jugador
    Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    AudioSource jumpAudioSource;

    // Estadisticas del jugador

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = 0.3f;
    [SerializeField] float coyoteTime = 0.25f;
    
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float[] jumpForce = {15, 17, 20};
    
    [SerializeField] float jumpBoostTime = 0.35f;
    
    [SerializeField] float gravity = 7.5f;
    [SerializeField] float reducedGravity = 2.5f;
    
    [SerializeField] float minSpeedForBoostedJump = 6;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] float runSpeed = 10f;


    // variables internas de control
    bool isGrounded;
    float remaningCoyoteTime;
    int currentJump = 0;
    float remainingJumpBoostTime;
    bool isJumping;
    bool isRunning;
    float horizontalInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Input del jugador
        horizontalInput = Input.GetAxis("Horizontal");

        // Comprobar si el jugador esta tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Comprobar si el jugador esta en el aire para el coyote time y saltos largos
        if (isGrounded && !isJumping)
        {
            remaningCoyoteTime = coyoteTime;
            if(remainingJumpBoostTime > 0) remainingJumpBoostTime -= Time.deltaTime;
        }
        else
        {
            remaningCoyoteTime -= Time.deltaTime;
        }

        if(remainingJumpBoostTime <= 0)
        {
            currentJump = 0;
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || remaningCoyoteTime > 0))
        {
            isJumping = true;
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        // correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
            currentJump = 0;
        }

        // modificacion de gravedad para saltos mas cortos o largos
        if (!isGrounded && Input.GetKey(KeyCode.Space) && isJumping)
        {
            rb.gravityScale = reducedGravity;
        }
        else
        {
            rb.gravityScale = gravity;
        }        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float speed = isRunning ? runSpeed : moveSpeed;
        Vector2 targetVelocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Si el jugador esta en el aire y no se esta moviendo horizontalmente, permitir el movimiento vertical
        // pero no horizontal, esto evita que el jugador se quede pegado a las paredes
        if (!isGrounded && Mathf.Abs(rb.velocity.x) <= 0.01f)
        {
            targetVelocity.x = 0;
        }

        rb.velocity = targetVelocity;
    }

    void Jump()
    {
        if (isRunning && currentJump == 0)
        {
            remainingJumpBoostTime = jumpBoostTime;
        }

        // Resetear el coyote time
        remaningCoyoteTime = 0;

        // Resetear la velocidad vertical para evitar saltos dobles
        rb.velocity = new Vector2( rb.velocity.x, 0);

        // Saltar
        jumpAudioSource.Play();
        rb.AddForce(Vector2.up * jumpForce[Mathf.Abs(rb.velocity.x) > minSpeedForBoostedJump ? currentJump : 0], ForceMode2D.Impulse);

        // Cambiar de salto normal a salto largo
        if (isRunning && currentJump < jumpForce.Length - 1 && remainingJumpBoostTime > 0 && Mathf.Abs(rb.velocity.x) > minSpeedForBoostedJump)
        {
            remainingJumpBoostTime = jumpBoostTime;
            currentJump++;
        }
        else
        {
            currentJump = 0;
        }
    }
}
