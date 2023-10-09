using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ParallaxBG>() != null) { return; }

        if (collision.transform.parent.gameObject != null)
            Destroy(collision.transform.parent.gameObject);
        else
            Destroy(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ParallaxBG>() != null) { return; }

        if (collision.transform.parent.gameObject != null)
            Destroy(collision.transform.parent.gameObject);
        else
            Destroy(collision.gameObject);
    }
}
