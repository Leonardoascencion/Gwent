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
    public bool EffectUsed = false;
    public bool ActiveEffect = false;

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
        if (GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Name.text != Name)
        {
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Name.text = Name;
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Attack.text = "none";

            if (BelongsPlayer1)
                GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Effect.text = "Inmune";
            else
                GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Effect.text = "UnfairDraw";

            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Range.text = "" + EffectUsed.ToString();
        }
        else
        {
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = DefaultSprite;
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Name.text = "";
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Attack.text = "";
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Effect.text = "";
            GameObject.Find("ShowCard").GetComponent<ShowBehavior>().Range.text = "";
        }

        /*         //allows to use the leader efect one time for round and only uses the owner of the card
                if (!EffectUsed && GameManager.Instance.TurnPlayer1 == BelongsPlayer1 && GameManager.Instance.TurnPlayer2 != BelongsPlayer1)
                {
                    if (Scope.FirstExampleCard != null && LiderEfects == Especial.LiderEffect.Inmune)
                    {
                        Scope.FirstExampleCard.GetComponent<Cards>().Afected = false;
                        EffectUsed = true;
                    }
                } 
        */
        if (!EffectUsed)
        {
            ActiveEffect = !ActiveEffect;
            Debug.Log("activeeffect");
        }
    }

    public void Update()
    {
        if (LiderEfects == Especial.LiderEffect.Inmune)
            if (ActiveEffect && Scope.FirstExampleCard != null && !Scope.FirstExampleCard.ItIsInHand)
            {
                Scope.FirstExampleCard.Afected = false;
                EffectUsed = true;
                Debug.Log("inmuno");
            }
    }
}
