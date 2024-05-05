using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDamage : MonoBehaviour
{
    public GameObject texto;
    public GameObject Fila;



    void Update()
    {
        int suma = 0;
        if (Fila.transform.childCount > 0)
            for (int i = 0; i < Fila.transform.childCount; i++)
            {
                suma += Fila.GetComponentInChildren<Cards>().Attack;
            }
        texto.GetComponent<Text>().text = "" + suma;
    }
}