using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D thisRigidbody;
    const float SPEED = 8f;
    float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        speedModifier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Debug.Log(xMovement + " " + yMovement);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier = 3f;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedModifier = 1f;
        }

        // Move
        thisRigidbody.velocity = new Vector2(xMovement * SPEED * speedModifier, yMovement * SPEED * speedModifier);
    }
}
