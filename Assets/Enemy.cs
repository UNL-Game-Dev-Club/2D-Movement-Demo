using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;
    Rigidbody2D thisRigidBody;
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        thisRigidBody = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thisPosition = this.transform.position;
        Vector2 targetPosition = target.transform.position;
        float xdiff = targetPosition.x - thisPosition.x;
        float ydiff = targetPosition.y - thisPosition.y;

        float distance = GetDistance();
        if (distance < 0.8f)
        {
            xdiff = 0;
            ydiff = 0;


        }

        Vector2 direction = new Vector2(xdiff, ydiff);
        direction.Normalize();

        thisRigidBody.velocity = direction * speed;
    }

    float GetDistance()
    {
        Vector2 thisPosition = this.transform.position;
        Vector2 targetPosition = target.transform.position;

        float xdiff = Mathf.Abs(targetPosition.x - thisPosition.x);
        float ydiff = Mathf.Abs(targetPosition.y - thisPosition.y);

        float xsquared = Mathf.Pow(xdiff, 2);
        float ysquared = Mathf.Pow(ydiff, 2);

        float distance = Mathf.Sqrt(xsquared + ysquared);
        return distance;

    }
}
