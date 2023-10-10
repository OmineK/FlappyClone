using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float obstacleMoveSpeed;

    void Update()
    {
        transform.position += Vector3.left * obstacleMoveSpeed * Time.deltaTime; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.UpdateScore();
    }
}
