using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    SpriteRenderer s;

    private void Start()
    {
        s = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        s.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
    }


}