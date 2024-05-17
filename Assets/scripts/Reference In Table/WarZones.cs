using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EspecialHabilities;
// script asociate to the Melee, Range, Assedium  zones of each player 
public class WarZone : MonoBehaviour
{
    public Especial.CombatZone Belong;
    public int DamgeAffected = 0;
    public int LastDamgeAffected = 0;
    public GameObject AsociateZone;


/*     private void Update()
    {
        if (DamgeAffected != 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
                if (gameObject.transform.GetChild(i).GetComponent<Cards>().Afected)
                    gameObject.transform.GetChild(i).GetComponent<Cards>().Attack += LastDamgeAffected;
            LastDamgeAffected += DamgeAffected;

        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Cards>().Attack -= DamgeAffected;
        }

        DamgeAffected = 0;
    } */

}

