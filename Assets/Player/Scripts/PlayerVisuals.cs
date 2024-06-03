using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(rb.velocity.x != 0) sprite.flipX = rb.velocity.x < 0;
        anim.SetFloat("walkVel", rb.velocity.x * 0.125f);
        anim.SetFloat("yVel", rb.velocity.y);
        anim.SetBool("isFalling", rb.velocity.y != 0);
        anim.SetBool("isWalking", rb.velocity.x != 0);
    }
}
