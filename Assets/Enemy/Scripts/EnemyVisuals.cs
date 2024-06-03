using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyVisuals : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb.velocity.x != 0) sprite.flipX = rb.velocity.x > 0;
        anim.SetFloat("walkVel", rb.velocity.x * 0.125f);
        anim.SetBool("isWalking", rb.velocity.x != 0);
    }
}
