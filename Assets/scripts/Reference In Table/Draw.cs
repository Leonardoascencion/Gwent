using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

//Funciona el Sistema de robar
public class Draw : MonoBehaviour
{
    public GameObject Button;
    public GameObject RealDeck;
    public GameObject Hand;
    public bool BelongsPlayer1;

    private void Start()
    {
        if (gameObject.transform.parent.name == "HandZonePlayer1")
        {
            Hand = GameObject.Find("HandPlayer1");
            RealDeck = GameObject.Find("RealDeckPlayer1");
        }
        else
        {
            Hand = GameObject.Find("HandPlayer2");
            RealDeck = GameObject.Find("RealDeckPlayer2");
        }

        if (Hand == GameObject.Find("HandPlayer1"))
            BelongsPlayer1 = true;
        else
            BelongsPlayer1 = false;

        InitialDraw();
    }


    public void Update()
    {
        if (Hand.transform.childCount > 10)
        {
            for (int i = 10; i < Hand.transform.childCount; i++)
            {
                if (BelongsPlayer1) Hand.transform.GetChild(i).transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
                else Hand.transform.GetChild(i).transform.SetParent(GameObject.Find("GravePlayer2").transform, false);
            }

        }
        for (int i = 0; i < Hand.transform.childCount; i++)
            if (Hand.transform.GetChild(i).GetComponent<Cards>())
                Hand.transform.GetChild(i).GetComponent<Cards>().Attack = Hand.transform.GetChild(i).GetComponent<Cards>().OriginalAttack;

        if (BelongsPlayer1)
        {
            if (GameManager.Instance.StartRound1)
                for (int i = 0; i < 2; i++)
                    DrawFunction();
            GameManager.Instance.StartRound1 = false;
        }
        else
        if (GameManager.Instance.StartRound2)
            for (int i = 0; i < 2; i++)
                DrawFunction();
        GameManager.Instance.StartRound2 = false;

        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            Hand.transform.GetChild(i).GetComponent<Cards>().ItIsInHand = true;
        }
    }

    public void DrawFunction()
    {
        if (!GameManager.Instance.ENDGAME)
            if (GameManager.Instance.StartTurn)
                if (GameManager.Instance.TurnPlayer1 == BelongsPlayer1 && GameManager.Instance.TurnPlayer2 != BelongsPlayer1)
                {
                    int Maxim = Hand.transform.childCount;
                    int Total = RealDeck.transform.childCount;
                    int randomnumber = UnityEngine.Random.Range(0, Total - 1);
                    if (RealDeck.transform.childCount > 0)//check if there is spots for cards in hand and cards in deck
                        RealDeck.transform.GetChild(randomnumber).SetParent(Hand.transform, false);
                    GameManager.Instance.StartTurn = false;
                    Debug.Log("Robo");
                }
    }

    public void InitialDraw()
    {
        for (int i = 0; i < 10; i++) //draw 10 cards
        {
            int Maxim = Hand.transform.childCount;
            int Total = RealDeck.transform.childCount;
            int randomnumber = UnityEngine.Random.Range(0, Total - 1);
            if (Maxim < 10 && RealDeck.transform.childCount > 0)//check if there is spots for cards in hand and cards in deck
                RealDeck.transform.GetChild(randomnumber).SetParent(Hand.transform, false);
        }

    }
}
