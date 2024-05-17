using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using EspecialHabilities;
using System.IO;


public class Cards : MonoBehaviour
{
    //    public Card Property { get; set; } no se usarlo ahora mismo
    public string Name;
    public int Attack = 10;
    public int OriginalAttack = 0;
    public bool Afected = true;
    public bool ItIsInHand = true;
    public List<Especial.CombatZone> BelongsPositiions;
    public Especial.MonsterEffect monsterEfects;

    public Text ShowCard;

    //this make posible the turns of the game
    public bool BelongsPlayer1;

    //this is a cosmetic basically
    private Sprite DefaultSprite;

    public void Start()
    {
        OriginalAttack = Attack;
        DefaultSprite = GameObject.Find("ShowCard").GetComponent<Image>().sprite;
    }
    public void Update()
    {
        if (gameObject.transform.parent.GetComponent<WarZone>())
        {
            if (Afected)
                Attack = OriginalAttack + gameObject.transform.parent.GetComponent<WarZone>().DamgeAffected;
        }
        if(Scope.FirstExampleCard == gameObject)
        ShowCard.text = ShowCard.ToString();
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

        //4to in the midle of the game it will change constantly
        if (monsterEfects == Especial.MonsterEffect.Inmune)
            if (Afected)
                if ((GameManager.Instance.Contador % 2) == 0)
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
        if (monsterEfects == Especial.MonsterEffect.BoostTypeA)
            Attack = gameObject.transform.parent.transform.childCount * Attack;

        //2d
        if (monsterEfects == Especial.MonsterEffect.BoostTypeB)
            Attack = GameManager.Instance.Contador * Attack;

        //3er
        if (monsterEfects == Especial.MonsterEffect.ReInvoke)
            ItIsInHand = true;
        //5to
        if (monsterEfects == Especial.MonsterEffect.BossDestroy)
            if (gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.childCount != 0)
            {
                int Compare = int.MinValue;
                for (int i = 0; i <= gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.childCount - 1; i++)
                {
                    if (gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(i).GetComponent<Cards>().Afected)
                        if (Compare < gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(i).GetComponent<Cards>().Attack)
                            Compare = i;
                }
                if (Compare >= 0)
                    if (gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(Compare).GetComponent<Cards>().BelongsPlayer1)
                        gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(Compare).SetParent(GameObject.Find("GravePlayer1").transform, false);
                    else
                        gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(Compare).SetParent(GameObject.Find("GravePlayer2").transform, false);
            }
        //6to
        if (monsterEfects == Especial.MonsterEffect.Draw)
        {
            GameObject Deck;
            GameObject Hand;
            if (BelongsPlayer1)
            {
                Deck = GameObject.Find("RealDeckPlayer1");
                Hand = GameObject.Find("HandPlayer1");
            }
            else
            {
                Deck = GameObject.Find("RealDeckPlayer2");
                Hand = GameObject.Find("HandPlayer2");
            }

            int Maxim = Hand.transform.childCount;
            int Total = Deck.transform.childCount;
            int randomnumber = UnityEngine.Random.Range(0, Total - 1);
            if (Maxim < 10 && Deck.transform.childCount > 0)//check if there is spots for cards in hand and cards in deck
                Deck.transform.GetChild(randomnumber).SetParent(Hand.transform, false);

        }
        //7mo
        if (monsterEfects == Especial.MonsterEffect.EstupidEliminate)
            for (int i = 0; i < gameObject.transform.parent.childCount; i++)
                if (gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(i).GetComponent<Cards>().BelongsPlayer1)
                    gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer1").transform, false);
                else
                    gameObject.transform.parent.GetComponent<WarZone>().AsociateZone.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer2").transform, false);

        //8vo
        if (monsterEfects == Especial.MonsterEffect.Suicide)
        {
            int randomnumber = UnityEngine.Random.Range(1, gameObject.transform.parent.childCount - 1);
            int Count = gameObject.transform.parent.childCount;

            for (int i = 0; i < Count - 1; i++)
                if (gameObject.transform.GetChild(i).GetComponent<Cards>().Afected)
                    gameObject.transform.GetChild(i).GetComponent<Cards>().Attack += Attack / randomnumber;

            if (gameObject.transform.GetComponent<Cards>().BelongsPlayer1)
                gameObject.transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
            else
                gameObject.transform.SetParent(GameObject.Find("GravePlayer2").transform, false);


        }




    }
}
