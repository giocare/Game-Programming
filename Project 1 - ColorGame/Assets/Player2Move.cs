using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{

    float speed;
    float jumpForce;
    float moveInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        jumpForce = 8;
        rb = GetComponent<Rigidbody2D>();
    }

      void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("P2Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}