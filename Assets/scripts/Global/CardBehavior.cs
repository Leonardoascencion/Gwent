using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using position;
using System.IO;


public class Cards : MonoBehaviour
{
    //    public Card Property { get; set; } no se usarlo ahora mismo
    public string Name;
    public int Id = 0;
    public int Attack = 10;
    public int OriginalAttack;
    public bool Afected = true;
    public bool ItIsInHand = true;
    public List<Position.CombatZone> BelongsPositiions;
    public Position.MonsterEffect monsterEfects;


    //this make posible the turns of the game
    public bool BelongsPlayer1;

    //this is a cosmetic basically
    private Sprite DefaultSprite;

    public void Start()
    {
        OriginalAttack = Attack;
        DefaultSprite = GameObject.Find("ShowCard").GetComponent<Image>().sprite;
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.TurnPlayer1 == BelongsPlayer1 && GameManager.Instance.TurnPlayer2 != BelongsPlayer1)
        {
            if (Scope.SecondExampleCard == null)
                Scope.SecondExampleCard = this.gameObject;

            if (Scope.FirstExampleCard == this)
            {
                Scope.FirstExampleCard = null;
                GameObject.Find("ShowCard").GetComponent<Image>().sprite = DefaultSprite;
            }
            else
            {
                Scope.FirstExampleCard = this;
                GameObject.Find("ShowCard").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            }
        }

        //case of card eliminate clima
        /*  if (Scope.FirstExampleCard != null && Scope.SecondExampleCard != null)
         {
             for (int i = 0; i < BelongsPositiions.Count; i++)
                 if (Scope.FirstExampleCard.BelongsPositiions[i] == Position.CombatZone.Debuf)
                 {
                     Debug.Log("paso el 1  if");
                     if (Scope.FirstExampleCard.transform.parent == GameObject.Find("Climate"))
                     {
                         Debug.Log("paso el 2  if");
                         if (Scope.SecondExampleCard.GetComponent<Cards>().BelongsPositiions[i] == Position.CombatZone.Clear)
                         {
                             Debug.Log("paso el 3 if");
                             Scope.FirstExampleCard.transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
                             Scope.SecondExampleCard.transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
                             Scope.FirstExampleCard = null;
                             Scope.SecondExampleCard = null;
                             break;
                         }
                     }
                 }
         } */
         //4to
        if ((GameManager.Instance.contador % 2) == 0)
        {
            Afected = false;
        }
    }


    void OnMouseEnter()
    {
        if (gameObject.transform.parent.name != "GravePlayer1" && gameObject.transform.parent.name != "GravePlayer2")
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);

    }

    void OnMouseExit()
    {
        if (gameObject.transform.parent.name != "GravePlayer1" && gameObject.transform.parent.name != "GravePlayer2")
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
    }

    public void Efect()
    {
        //1er
        Attack = gameObject.transform.parent.transform.childCount * Attack;

        //2d
        Attack = GameManager.Instance.contador * Attack;

        //3er
        ItIsInHand = true;
    }
}
