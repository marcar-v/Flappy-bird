using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    
    public float upForce = 200f;

    private RotateBird rotateBird;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
    }

    void Update()
    {
        if (isDead) return;
        
        if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * upForce);
                anim.SetTrigger("Flap");
                SoundSystem.instance.PlayFlap();
            }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        anim.SetTrigger("Die");
        rotateBird.enabled = false;
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
    }
}
