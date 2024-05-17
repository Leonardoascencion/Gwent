using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using EspecialHabilities;
using System.IO;


public class Leader : MonoBehaviour
{
    public string Name;
    public Especial.LiderEffect LiderEfects;
    public bool BelongsPlayer1;
    public bool EfectUsed = false;

    //dont touch
    private Sprite DefaultSprite;


    public void Start()
    {
        DefaultSprite = GameObject.Find("ShowCard").GetComponent<Image>().sprite;

        if (gameObject.transform.parent.name == "LeaderZonePlayer1")
            BelongsPlayer1 = true;
        else
            BelongsPlayer1 = false;
    }

    private void OnMouseDown()
    {
        if (GameObject.Find("ShowCard").GetComponent<Image>().sprite != gameObject.GetComponent<Image>().sprite)
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        else
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = DefaultSprite;

        //allows to use the leader efect one time for round and only uses the owner of the card
        if (!EfectUsed && GameManager.Instance.TurnPlayer1 == BelongsPlayer1 && GameManager.Instance.TurnPlayer2 != BelongsPlayer1)
        {
            if (Scope.FirstExampleCard != null && LiderEfects == Especial.LiderEffect.Inmune)
            {
                Scope.FirstExampleCard.GetComponent<Cards>().Afected = false;
                EfectUsed = true;
            }
        }
    }
}
