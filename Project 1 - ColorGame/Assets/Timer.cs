using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public int timeLeft = 20;
    public GameObject[] platforms;
    public GameObject targetPlatform;
    public Text loseText;
    public Slider countdown;

    public GameObject Player1;
    public GameObject Player2;
    SpriteRenderer P1Sprite;
    SpriteRenderer P2Sprite; 
    Rigidbody2D rb1; 

    public Text P1Death;
    public Text P2Death;

    public bool P1AliveStatus = true;
    public bool P2AliveStatus = true;

    void Start()
    {
        StartCoroutine("LoseTime");
        P1Sprite = Player1.GetComponent<SpriteRenderer>();
        P2Sprite = Player2.GetComponent<SpriteRenderer>();
        countdown.value = timeLeft;

        P1Death.text = "PLAYER 1 : ALIVE";
        P2Death.text = "PLAYER 2 : ALIVE";
        rb1 = GetComponent<Rigidbody2D>();

        


    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player 1"){
            Object.Destroy(other);
            P1Death.text = "PLAYER 1 : " + "<color=red>DEAD</color>";
            P1AliveStatus = false;
            
        }
         if(other.tag == "Player 2"){
            Object.Destroy(other);
            P2Death.text = "PLAYER 2 : " + "<color=red>DEAD</color>";
            P2AliveStatus = false;
        }

    }


    void FixedUpdate()
    {

        // isP1Alive = deathScript.P1AliveStatus;
        // isP2Alive = deathScript.P2AliveStatus;
        
        timerText.text = ("Time Left = " + timeLeft);
        if (timeLeft <= 0 && P1AliveStatus == true && P1AliveStatus == true)
        {
            StopCoroutine("LoseTime");
            timerText.text = "Times Up!";
            

            if (P1Sprite.color == targetPlatform.GetComponent<SpriteRenderer>().color && P1AliveStatus == true) 
            {
                loseText.text = "PLAYER1 IS THE WINNER!!";
            }
            else if(P2Sprite.color == targetPlatform.GetComponent<SpriteRenderer>().color && P2AliveStatus == true)
            {
                loseText.text = "PLAYER2 IS THE WINNER!!";
            }
            else if(P1Sprite.color != targetPlatform.GetComponent<SpriteRenderer>().color && P2Sprite.color != targetPlatform.GetComponent<SpriteRenderer>().color){
                 loseText.text = "YOU BOTH LOSE!!";
            }
            else{
                loseText.text = "YOU BOTH LOSE!!";
            }
            Object.Destroy(Player1);
            Object.Destroy(Player2);
            
        }
        if(timeLeft > 0 && P1AliveStatus == false && P2AliveStatus == false){
            StopCoroutine("LoseTime");
            loseText.text = "YOU BOTH DIED!!";
        }
            
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            timeLeft -= 2;
            countdown.value -= 2;
            AssignColors();
            yield return new WaitForSeconds(2);
            
            
        }
    }

    public void AssignColors()
    {
        // array of colors
        Color[] colors = { new Color32(101, 191, 191, 255), new Color32(145, 217, 217, 255), new Color32(242, 116, 87, 255), new Color32(242, 100, 87, 255), new Color32(13, 13, 13, 255) };

        // random platform has the target color
        int index = pickPlatform();
        platforms[index].GetComponent<SpriteRenderer>().color = targetPlatform.GetComponent<SpriteRenderer>().color;

        for (int i = 0; i < platforms.Length; i++)
        {
            if (i != index)
            {
                platforms[i].GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
                while(platforms[i].GetComponent<SpriteRenderer>().color == platforms[index].GetComponent<SpriteRenderer>().color)
                {
                    platforms[i].GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
                }
            }
        }
        for (int i = 0; i < platforms.Length; i++)
        {
            if (ToTiltOrNot() == 1)
            {
                platforms[i].transform.Rotate(0f, 0f, 90f);
            }
        }
         
    }
    public int ToTiltOrNot()
    {
        float num = Random.Range(0, 1000);
        if (num % 4 == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

    public int pickPlatform()
    {
        int num = Random.Range(0, platforms.Length);
        return num;
    }
}
