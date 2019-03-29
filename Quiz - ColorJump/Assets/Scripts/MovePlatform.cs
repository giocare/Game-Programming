using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x - speed * Time.deltaTime, transform.localPosition.y);
        if(transform.localPosition.x < -9)
        {
            Destroy(this.gameObject);
        }
    }
}
