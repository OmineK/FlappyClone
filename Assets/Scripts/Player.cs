using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerFlyingUpVelocity;
    [SerializeField] float playerRotationSpeed;
    [SerializeField] float flyingUpDuration;

    float flyingUpTimer;
    bool flyingUp = false;

    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void Update()
    {
        VelocityTimer();
        PlayerAnimation();
        PlayerInputs();
    }

    void PlayerMovement()
    {
        if (flyingUp)
            rb.velocity = Vector3.up * playerFlyingUpVelocity;

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * playerRotationSpeed);
    }

    void VelocityTimer()
    {
        flyingUpTimer -= Time.deltaTime;

        if (flyingUp && (flyingUpTimer < 0))
            flyingUp = false;
    }

    void PlayerAnimation()
    {
        if (transform.rotation.z < 0)
            anim.speed = 0;
        else
            anim.speed = 1;
    }

    void PlayerInputs()
    {
        if (GameManager.instance.isPlaying == false && Input.GetKeyDown(KeyCode.Space))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;

            GameManager.instance.isPlaying = true;
            UI.instance.GameStartUI(!GameManager.instance.isPlaying);

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !flyingUp &&
        GameManager.instance.gamePause == false)
        {
            flyingUp = true;
            flyingUpTimer = flyingUpDuration;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
