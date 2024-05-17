using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using EspecialHabilities;

public class SummonButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject Zone;
    public GameObject SecondZoneAsociate;
    public Especial.CombatZone ZoneBelong;
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
            int Total2 = SecondZoneAsociate.transform.childCount;
            int Deugrade = Scope.FirstExampleCard.GetComponent<Cards>().Attack;
            ZoneBelong = Zone.GetComponent<WarZone>().Belong;

            for (int i = 0; i < SiceList; i++)
            {
                //Case of Normal Monster
                if (Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == ZoneBelong)
                    if (Zone.transform.childCount < 5)
                    {
                        GameManager.Instance.ChangeTurn();
                        Scope.FirstExampleCard.transform.SetParent(Zone.transform, false);
                        Scope.FirstExampleCard.ItIsInHand = false;
                        Scope.FirstExampleCard.Efect();
                        break;
                    }

                //Case of Climmate
                if (Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == Especial.CombatZone.Debuf && Scope.ClimateZone.transform.childCount < 3)
                {

                    Scope.FirstExampleCard.transform.SetParent(Scope.ClimateZone.transform, false);
                    /*   for (int j = 0; j < Total; j++)
                      {
                          if (Zone.transform.GetChild(i).GetComponent<Cards>().Afected)
                              Zone.transform.GetChild(i).GetComponent<Cards>().Attack -= Deugrade;
                      }

                      for (int j = 0; j < Total2; j++)
                      {
                          if (Zone.transform.GetChild(i).GetComponent<Cards>().Afected)
                              Zone.transform.GetChild(i).GetComponent<Cards>().Attack -= Deugrade;
                      }
                     */

                    Zone.GetComponent<WarZone>().DamgeAffected += Deugrade;
                    SecondZoneAsociate.GetComponent<WarZone>().DamgeAffected += Deugrade;
                    GameManager.Instance.ChangeTurn();
                    break;
                }
                // case of target
                if (Scope.FirstExampleCard.GetComponent<Cards>().BelongsPositiions[i] == Especial.CombatZone.Target)
                {
                    List<GameObject> auxList = new();
                    for (int j = 0; j < Total; j++)
                        if (Zone.transform.GetChild(j).GetComponent<Cards>().Afected)
                            if (Zone.transform.GetChild(j).GetComponent<Cards>().BelongsPositiions[0] != Especial.CombatZone.Target)
                                auxList.Add(Zone.transform.GetChild(j).gameObject);
                    if (auxList.Count != 0)
                    {
                        int randomnumber = UnityEngine.Random.Range(0, auxList.Count - 1);
                        if (auxList[randomnumber].GetComponent<Cards>().BelongsPlayer1)
                            Zone.transform.GetChild(randomnumber).transform.SetParent(GameObject.Find("HandPlayer1").transform, false);
                        else
                            Zone.transform.GetChild(randomnumber).transform.SetParent(GameObject.Find("HandPlayer2").transform, false);
                    }
                    Scope.FirstExampleCard.transform.SetParent(Zone.transform, false);
                    GameManager.Instance.ChangeTurn();
                }

                //Case of Clear
                if (Scope.FirstExampleCard.BelongsPositiions[i] == EspecialHabilities.Especial.CombatZone.Clear && Scope.ClimateZone.transform.childCount > 0)
                {
                    Scope.FirstExampleCard.transform.SetParent(Scope.ClimateZone.transform, false);
                    for (int j = Scope.ClimateZone.transform.childCount - 1; j >= 0; j--)
                        if (Scope.ClimateZone.transform.GetChild(j).GetComponent<Cards>().BelongsPlayer1)
                            Scope.ClimateZone.transform.GetChild(j).SetParent(GameObject.Find("GravePlayer1").transform, false);
                        else
                            Scope.ClimateZone.transform.GetChild(j).SetParent(GameObject.Find("GravePlayer2").transform, false);
                    GameManager.Instance.ChangeTurn();
                }
            }
            Scope.FirstExampleCard = null;
        }
    }



}

