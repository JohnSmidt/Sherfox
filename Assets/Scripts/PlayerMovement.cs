using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        speed = Input.GetButton("Run") ? 7.5f : 5f;
        
        if(horizontal != 0 && vertical != 0)
        {
            transform.position += (Vector3.right * (speed * 0.707f) * Time.deltaTime) * horizontal;
            transform.position += Vector3.up * (speed * 0.707f) * Time.deltaTime * vertical;
        }
        else
        {
            if(horizontal != 0)
            {
                transform.position += (Vector3.right * speed * Time.deltaTime) * horizontal;
            }

            if(vertical != 0)
            {
                transform.position += Vector3.up * speed * Time.deltaTime * vertical;
            }
        }
    }
}
