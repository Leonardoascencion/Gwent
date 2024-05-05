using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    public GameObject Button;
    public GameObject RealDeck;
    public GameObject Hand;
    public bool InitialDrawVerify;

    public void DrawFunction()//verificar al final si funciona el random
    {
        int Maxim = Hand.transform.childCount;
        int Total = RealDeck.transform.childCount;
        int randomnumber = UnityEngine.Random.Range(0, Total - 1);
        if (Maxim < 10 && RealDeck.transform.childCount > 0)//check there is spots for cards in hand and cards in deck
            RealDeck.transform.GetChild(randomnumber).SetParent(Hand.transform, false);

    }

    public void InitialDraw()
    {
        if (InitialDrawVerify)//check round start
        {
            for (int i = 0; i < Hand.transform.childCount; i++)//send cards in hand to grave before start the draw
                Hand.transform.GetChild(i).SetParent(Scope.CardsInGraveZone.transform, false);

            for (int i = 0; i < 10; i++) //draw 10 cards
                DrawFunction();
        }
    }
}
