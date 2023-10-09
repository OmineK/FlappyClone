using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] float parallaxSpeed;

    float length;

    void Awake()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (transform.position.x < -length)
            transform.position = new Vector3(0, transform.position.y);

        transform.position += Vector3.left * parallaxSpeed * Time.deltaTime;
    }
}
