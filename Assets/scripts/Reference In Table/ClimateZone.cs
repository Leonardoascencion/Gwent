using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EspecialHabilities;

public class ClimateZone : MonoBehaviour
{
    public void Awake()
    {
        Scope.ClimateZone = this;
    }

/*     public void OnMouseDown()
    {
        if (Scope.ExampleCard != null)
            for (int i = 0; i < Scope.ExampleCard.Belongs.Count; i++)
                if (Scope.ExampleCard.Belongs[i] == Posiciones.CombatZone.Debuf)
                    if (transform.childCount < 3)
                    {
                        Scope.ExampleCard.transform.SetParent(this.gameObject.transform, false);
                        Scope.ExampleCard.ItIsInHand = false;
                    }
        Scope.ExampleCard = null;
    } */


}
