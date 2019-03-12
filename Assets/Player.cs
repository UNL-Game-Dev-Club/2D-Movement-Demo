using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D thisRigidbody;
    float speed = 8f;

    void Start()
    {
        thisRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Debug.Log(xMovement + " " + yMovement);

        thisRigidbody.velocity = new Vector2(xMovement, yMovement) * speed;
    }
}
