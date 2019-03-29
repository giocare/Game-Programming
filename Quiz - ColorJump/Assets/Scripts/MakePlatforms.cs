using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlatforms : MonoBehaviour
{
    public GameObject[] prefab;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
       
            GameObject p;
            p = Instantiate(prefab[Random.Range(0, prefab.Length)], new Vector2(Random.Range(4.4f, 9f), Random.Range(-4.4f, 5f)), Quaternion.identity);
            p.transform.localScale = new Vector2(Random.Range(3,4), 0.2f);
            timer = 0;

        }
    }

    
}
