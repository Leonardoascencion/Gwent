using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// script that count the total damage of the zone asociate 
public class MeleeDamage : MonoBehaviour
{
    public GameObject texto;
    public GameObject Fila;

    void Start()
    {
        texto.GetComponent<Text>().text = "0";
    }


    void Update()
    {
        int suma = 0;
        if (Fila.transform.childCount > 0)
            for (int i = 0; i < Fila.transform.childCount; i++)
            {
                suma += Fila.transform.GetChild(i).GetComponent<Cards>().Attack;
            }
        texto.GetComponent<Text>().text = "" + suma;
    }
}