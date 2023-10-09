using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSwimmingUpVelocity;
    [SerializeField] float playerRotationSpeed;
    [SerializeField] float swimmingUpDuration;

    float swimmingUpTimer;
    bool swimmingUp = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (swimmingUp)
            rb.velocity = Vector3.up * playerSwimmingUpVelocity;

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * playerRotationSpeed);
    }

    void Update()
    {
        swimmingUpTimer -= Time.deltaTime;

        if (swimmingUp && (swimmingUpTimer < 0))
            swimmingUp = false;

        if (Input.GetKeyDown(KeyCode.Space) && !swimmingUp)
        {
            swimmingUp = true;
            swimmingUpTimer = swimmingUpDuration;
        }
    }
}
