using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    float speed;
    int horizontalMove;
    int verticalMove;
    bool moving = false;

    float waitTime = 0f;
    float moveTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        waitTime = Random.Range(0f, 3f);
        speed = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D downHit = Physics2D.Raycast(transform.position, Vector2.down, 1);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.left, 1);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D upHit = Physics2D.Raycast(transform.position, Vector2.up, 1);
        // Debug.DrawRay(transform.position, Vector2.up, Color.cyan);
        // Debug.DrawRay(transform.position, Vector2.down, Color.cyan);
        // Debug.DrawRay(transform.position, Vector2.left, Color.cyan);
        // Debug.DrawRay(transform.position, Vector2.right, Color.cyan);
        if(!moving)
        {
            if(waitTime <= 0)
            {
                moving = true;
                moveTime = Random.Range(0f, 4f);
                horizontalMove = Random.Range(-1 * System.Convert.ToInt32(rightHit.collider == null),
                                                2 - System.Convert.ToInt32(leftHit.collider != null));
                //horizontalMove = Random.Range(-1, 2);
                //Debug.Log(horizontalMove);
                verticalMove = Random.Range(-1 * System.Convert.ToInt32(downHit.collider == null),
                                                2 - System.Convert.ToInt32(upHit.collider != null));
            }
            else
                waitTime -= Time.deltaTime;
        }
        else
        {
            if(moveTime > 0)
            {
                if(horizontalMove != 0 && verticalMove != 0)
                {
                    transform.position += (Vector3.right * (speed * 0.707f) * Time.deltaTime) * horizontalMove;
                    transform.position += Vector3.up * (speed * 0.707f) * Time.deltaTime * verticalMove;
                }
                else
                {
                    transform.position += (Vector3.right * speed * Time.deltaTime) * horizontalMove;
                    transform.position += Vector3.up * speed * Time.deltaTime * verticalMove;
                }
                moveTime -= Time.deltaTime;
            }
            else
            {
                moving = false;
                waitTime = Random.Range(0f, 3f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("bonk");
        moveTime = 0;
    }
}
