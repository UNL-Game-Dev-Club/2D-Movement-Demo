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
    const float DIST_THRESHHOLD = 0.5f;

    // Debug Only
    Text diffText;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        // target = GameObject.FindGameObjectWithTag("Player");

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

        diffText.text = "X diff = " + xdiff + "    ydiff = " + ydiff;

        /*if (Mathf.Abs(xdiff) > DIST_THRESHHOLD || Mathf.Abs(ydiff) > DIST_THRESHHOLD)
        {
            //transform.Translate(new Vector2(xdiff, ydiff) * SPEED);
            

        }*/
        if (Mathf.Abs(xdiff) < DIST_THRESHHOLD && Mathf.Abs(ydiff) < DIST_THRESHHOLD)
        {
            //transform.Translate(new Vector2(xdiff, ydiff) * SPEED);

            xdiff = 0;
            ydiff = 0;
        }

        Vector2 direction = new Vector2(xdiff, ydiff);
        direction.Normalize();

        thisRigidbody.velocity = direction * SPEED;
    }
}
