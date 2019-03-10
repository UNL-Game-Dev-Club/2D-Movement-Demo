using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject target;
    Rigidbody2D thisRigidbody;

    Vector2 targetPos;
    Vector2 thisPos;

    float xdiff;
    float ydiff; // for 3D, use zdiff

    const float SPEED = 3f;
    const float DIST_THRESHHOLD = 0.8f;

    // Debug Only
    Text diffText;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        // target = GameObject.FindGameObjectWithTag("Player");  // Another option

        thisRigidbody = GetComponent<Rigidbody2D>();

        diffText = GameObject.Find("DiffText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.transform.position;
        thisPos = this.transform.position;

        xdiff = targetPos.x - thisPos.x;
        ydiff = targetPos.y - thisPos.y;

        float distance = GetDistance(target.transform);
        if (distance < DIST_THRESHHOLD)
        {
            xdiff = 0;
            ydiff = 0;
        }

        Vector2 direction = new Vector2(xdiff, ydiff);
        direction.Normalize();

        thisRigidbody.velocity = direction * SPEED;
    }

    float GetDistance(Transform other)
    {
        Vector2 thisPos = transform.position;
        Vector2 otherPos = other.position;

        float xdiff = Mathf.Abs(otherPos.x - thisPos.x);
        float xsquared = Mathf.Pow(xdiff, 2);

        float ydiff = Mathf.Abs(otherPos.y - thisPos.y);
        float ysquared = Mathf.Pow(ydiff, 2);

        float distance = Mathf.Sqrt(xdiff + ydiff);

        diffText.text = "X diff = " + xdiff.ToString("0.00") + "    X squared = " + xsquared.ToString("0.00") + "\nY diff = " + ydiff.ToString("0.00") + "    Y squared = " + ysquared.ToString("0.00") + "\nDistance = " + distance;

        return distance;
    }
}
