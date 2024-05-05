using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using position;

public class SummonButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject Zone;
    public Posiciones.CombatZone ZoneBelong;

    public void OnButtonPress()
    {
        if (Scope.ExampleCard != null)
        {
            int SiceList = Scope.ExampleCard.GetComponent<Cards>().Belongs.Count;
            ZoneBelong = Zone.GetComponent<WarZone>().Belong;

            if (Scope.ExampleCard.ItIsInHand)
                for (int i = 0; i < SiceList; i++)
                    if (Scope.ExampleCard.GetComponent<Cards>().Belongs[i] == ZoneBelong || Scope.ExampleCard.GetComponent<Cards>().Belongs[i] == Posiciones.CombatZone.Target)
                    {
                        Scope.ExampleCard.transform.SetParent(Zone.transform, false);
                        Scope.ExampleCard.ItIsInHand = false;
                        Scope.ExampleCard = null;
                        break;
                    }
        }
    }
}
