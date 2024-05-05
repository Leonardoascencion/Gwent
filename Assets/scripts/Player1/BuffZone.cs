using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using position;
using Unity.VisualScripting;

public class BuffZone : MonoBehaviour
{
    public GameObject AsociateZone;
    public void OnMouseDown()
    {
        for (int i = 0; i < Scope.ExampleCard.Belongs.Count; i++)
            if (Scope.ExampleCard.Belongs[i] == Posiciones.CombatZone.Buff)
                if (Scope.ExampleCard != null)
                    if (transform.childCount == 0)
                    {
                        Scope.ExampleCard.transform.SetParent(this.gameObject.transform, false);
                        Scope.ExampleCard.ItIsInHand = false;
                        Buff();
                    }
        Scope.ExampleCard = null;
    }

    public void Buff()
    {
        int Total = AsociateZone.transform.childCount;
        int Ugrade = Scope.ExampleCard.Attack;
        for (int i = 0; i < Total; i++)
        {
            AsociateZone.transform.GetChild(i).GetComponent<Cards>().Attack += Ugrade;
        }
        Scope.ExampleCard.transform.SetParent(Scope.CardsInGraveZone.transform, false);
    }

}
