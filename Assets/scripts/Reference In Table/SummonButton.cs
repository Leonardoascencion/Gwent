using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using position;

public class SummonButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject Zone;
    public GameObject ZoneAsociate;
    public Position.CombatZone ZoneBelong;
    public bool BelongsPlayer1;

    void Start()
    {
        if (gameObject.transform.parent.tag == "CombatPlayer2")
            BelongsPlayer1 = false;
        else
            BelongsPlayer1 = true;
    }

    public void NormalSummon()
    {
        if (Scope.FirstExampleCard != null && Scope.FirstExampleCard.BelongsPlayer1 == BelongsPlayer1 && Scope.FirstExampleCard.ItIsInHand && GameManager.Instance.TurnPlayer1 == BelongsPlayer1)
        {
            int SiceList = Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions.Count;
            int Total = Zone.transform.childCount;
            int Total2 = ZoneAsociate.transform.childCount;
            int Deugrade = Scope.FirstExampleCard.GetComponent<Cards>().Attack;
            ZoneBelong = Zone.GetComponent<WarZone>().Belong;

            for (int i = 0; i < SiceList; i++)
            {
                //Case of Normal Monster
                if (Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == ZoneBelong || Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == Position.CombatZone.Target)
                {
                    Scope.FirstExampleCard.transform.SetParent(Zone.transform, false);
                    Scope.FirstExampleCard.ItIsInHand = false;
                    GameManager.Instance.TurnPlayer1 = !GameManager.Instance.TurnPlayer1;
                    GameManager.Instance.TurnPlayer2 = !GameManager.Instance.TurnPlayer2;
                    break;
                }
                //Case of Climmate
                // no se afectan las cartas q convocas despues de poner el clima
                if (Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == Position.CombatZone.Debuf && Scope.ClimateZone.transform.childCount < 3)
                {

                    Scope.FirstExampleCard.transform.SetParent(Scope.ClimateZone.transform, false);
                    for (int j = 0; j < Total; j++)
                    {
                        if (Zone.transform.GetChild(i).GetComponent<Cards>().Afected)
                            Zone.transform.GetChild(i).GetComponent<Cards>().Attack -= Deugrade;
                    }
                    for (int j = 0; j < Total2; j++)
                    {
                        if (Zone.transform.GetChild(i).GetComponent<Cards>().Afected)
                            Zone.transform.GetChild(i).GetComponent<Cards>().Attack -= Deugrade;
                    }
                    GameManager.Instance.TurnPlayer1 = !GameManager.Instance.TurnPlayer1;
                    GameManager.Instance.TurnPlayer2 = !GameManager.Instance.TurnPlayer2;
                    break;
                }

            }
            Scope.FirstExampleCard = null;
        }
        Scope.SecondExampleCard = null;
    }



}

