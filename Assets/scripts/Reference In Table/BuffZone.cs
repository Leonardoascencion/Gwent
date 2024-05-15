using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using position;
using Unity.VisualScripting;

//Script asociate to the Zones that invoque ugrades to the zone asociate
public class BuffZone : MonoBehaviour
{
    public GameObject AsociateZone;
    public bool BelongsPlayer1;

    public void Start()
    {
        if (gameObject.transform.parent.tag == "CombatPlayer2")
            BelongsPlayer1 = false;
        else BelongsPlayer1 = true;
    }

    public void OnMouseDown()
    {
        if (Scope.FirstExampleCard != null && Scope.FirstExampleCard.BelongsPlayer1 == BelongsPlayer1)
            for (int i = 0; i < Scope.FirstExampleCard.BelongsPositiions.Count; i++)
                if (Scope.FirstExampleCard.BelongsPositiions[i] == Position.CombatZone.Buff && Scope.FirstExampleCard.ItIsInHand)
                    if (transform.childCount == 0)
                    {
                        Scope.FirstExampleCard.transform.SetParent(this.gameObject.transform, false);
                        Scope.FirstExampleCard.ItIsInHand = false;
                        Buff();
                    }
        Scope.FirstExampleCard = null;

        /* nose si quiero q pase de turno o no        
                    GameManager.Instance.ChangeTurn(); */

    }

    //metod that increase the damage of all cards in the current zone
    public void Buff()
    {
        int Total = AsociateZone.transform.childCount;
        int Ugrade = Scope.FirstExampleCard.Attack;

        for (int i = 0; i < Total; i++)
        {
            if (AsociateZone.transform.GetChild(i).GetComponent<Cards>().Afected)
                AsociateZone.transform.GetChild(i).GetComponent<Cards>().Attack += Ugrade;
        }
        if (BelongsPlayer1)
            Scope.FirstExampleCard.transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
        else
            Scope.FirstExampleCard.transform.SetParent(GameObject.Find("GravePlayer2").transform, false);
    }

}
