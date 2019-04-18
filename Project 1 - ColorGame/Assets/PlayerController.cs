using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 50;

    public Rigidbody2D rb1;

    public Rigidbody2D rb2;

    public void Update()
    {
        //Player one (WASD)
        movePlayer(rb1, KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S);

        //Player two (Arrow keys)
        movePlayer(rb2, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);
    }

    void movePlayer(Rigidbody2D targetRg, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        Vector2 hAndV = getInput(targetRg, left, right, up, down);

        // Vector2 tempVect = new Vector2(hAndV.x, hAndV.y);
        // tempVect = tempVect.normalized * speed * Time.deltaTime;

        // Vector2 newPos = targetRg.transform.position + tempVect;
    }

    Vector2 getInput(Rigidbody2D targetRg, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        Vector2 input = Vector4.zero;

        //Horizontal
        if (Input.GetKey(left))
            input.x = -1;
        else if (Input.GetKey(right))
            input.x = 1;
        else
        {
            input.x = 0;
            targetRg.velocity = Vector3.zero;
            targetRg.angularVelocity = 0f;
        }

        //Vertical
        if (Input.GetKey(up))
            input.y = 1;
        else if (Input.GetKey(down))
            input.y = -1;
        else
        {
            input.y = 0;
            targetRg.velocity = Vector3.zero;
            targetRg.angularVelocity = 0f;
        }

        return input;
    }
}