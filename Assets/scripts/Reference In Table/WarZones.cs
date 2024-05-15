using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using position;
// script asociate to the Melee, Range, Assedium  zones of each player 
public class WarZone : MonoBehaviour
{
    public Position.CombatZone Belong;
    public int DamgeAffected = 0;
    public int LastDamgeAffected = 0;
    public bool Change;

    private void Update()
    {
        if (Change)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
                if (gameObject.transform.GetChild(i).GetComponent<Cards>().Afected)
                    gameObject.transform.GetChild(i).GetComponent<Cards>().Attack += LastDamgeAffected;
            LastDamgeAffected = DamgeAffected;
            Change = false;
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Cards>().Attack -= DamgeAffected;
        }

        DamgeAffected = 0;
    }

}

