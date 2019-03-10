using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D thisRigidbody;
    const float SPEED = 8f;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Debug.Log(xMovement + " " + yMovement);

        float speedModifier = 1;

        // Move
        thisRigidbody.velocity = new Vector2(xMovement * SPEED * speedModifier, yMovement * SPEED * speedModifier);
    }
}
