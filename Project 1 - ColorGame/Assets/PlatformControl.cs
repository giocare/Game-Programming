using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformControl : MonoBehaviour
{
    //float speed;
    public Text timeText;
    public float timeLeft = 10;
    SpriteRenderer s;


    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        //s.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //s.color = new Color(GetMeaning(), GetMeaning(), GetMeaning());
        Color[] colors = { new Color32(101, 191, 191, 255), new Color32(145, 217, 217, 255), new Color32(242, 116, 87, 255), new Color32(242, 100, 87, 255), new Color32(13, 13, 13, 255) };
        s.color = colors[Random.Range(0, colors.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMeaning()
    {
        float num = Random.Range(0, 1000);
        if(num % 2 == 0)
        {
            return 0.0f;
        }
        else
        {
            return 1.0f;
        }
        
    }
}
