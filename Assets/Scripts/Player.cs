using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement info")]
    [SerializeField] float playerFlyingUpVelocity;
    [SerializeField] float playerRotationSpeed;
    [SerializeField] float flyingUpDuration;

    [Header("Death particles")]
    [SerializeField] GameObject deathParticlesPref;

    float flyingUpTimer;
    bool flyingUp = false;

    Rigidbody2D rb;
    Animator anim;
    PolygonCollider2D birdCollider;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        birdCollider = GetComponent<PolygonCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.instance.isGameStart == false)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;

                GameManager.instance.isGameStart = true;
                UI.instance.GameStartUI(!GameManager.instance.isGameStart);

                return;
            }

            if (GameManager.instance.isGameOver)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            }

            if (!flyingUp && GameManager.instance.isGamePause == false)
            {
                PlayRandomBirdSFX();
                flyingUp = true;
                flyingUpTimer = flyingUpDuration;
            }
        }
    }

    void PlayRandomBirdSFX()
    {
        int randomSFX = UnityEngine.Random.Range(0, 3);

        if (randomSFX == 0)
            AudioManager.instance.PlaySFX(0);
        else if (randomSFX == 1)
            AudioManager.instance.PlaySFX(1);
        else if (randomSFX == 2)
            AudioManager.instance.PlaySFX(2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        birdCollider.enabled = false;
        Instantiate(deathParticlesPref, transform.position, Quaternion.identity);
        sr.enabled = false;

        GameManager.instance.GameOver();
    }
}
