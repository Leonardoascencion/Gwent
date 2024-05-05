using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using position;

public class ClimateZone : MonoBehaviour
{
    public GameObject AsociateZone;

    public void OnMouseDown()
    {
        for (int i = 0; i < Scope.ExampleCard.Belongs.Count; i++)
            if (Scope.ExampleCard.Belongs[i] == Posiciones.CombatZone.Debuf)
                if (Scope.ExampleCard != null)
                    if (transform.childCount < 3)
                    {
                        Scope.ExampleCard.transform.SetParent(this.gameObject.transform, false);
                        Scope.ExampleCard.ItIsInHand = false;
                    }
        Scope.ExampleCard = null;
    }


}
