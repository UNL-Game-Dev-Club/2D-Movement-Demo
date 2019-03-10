using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            GameObject.Find("Player").transform.position = Vector3.zero;
            GameObject.Find("Enemy").transform.position = new Vector3(0, 10, 0);
        }
    }
}
