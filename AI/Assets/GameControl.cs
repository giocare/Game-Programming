using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text[] buttonList;
    private string XorO;
    private int moveCount;

    void Awake()
    {
        SetGameControlRefrenceOnButtons();
        XorO = "X";
    }

    void SetGameControlRefrenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<GridSpace>().SetGameControlRefrence(this);
        }
    }

    public string GetPlayerSide()
    {
        return XorO;
    }

    public void EndTurn()
    {

        if(buttonList[0].text == XorO && buttonList[1].text == XorO && buttonList[2].text == XorO)
        {
            GameOver(XorO);
        }
        XorO = (XorO == "X") ? "O" : "X";
        moveCount++;
        if(moveCount > 8)
        {
            GameOver("No one");
        }

    }

    public void GameOver(string whoIs)
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        Debug.Log(whoIs + " is the winner!!");
    }
}
