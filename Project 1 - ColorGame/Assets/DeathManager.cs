using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public Text P1Death;
    public Text P2Death;

    public bool P1AliveStatus = true;
    public bool P2AliveStatus = true;

    // Start is called before the first frame update
    void Start()
    {
        P1Death.text = "PLAYER 1 : ALIVE";
        P2Death.text = "PLAYER 2 : ALIVE";


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player 1"){
            P1Death.text = "PLAYER 1 : " + "<color=red>DEAD</color>";
            P1AliveStatus = false;
        }
         if(other.tag == "Player 2"){
            P2Death.text = "PLAYER 2 : " + "<color=red>DEAD</color>";
            P2AliveStatus = false;
        }

    }
}
