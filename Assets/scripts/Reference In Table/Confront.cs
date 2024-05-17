using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confront : MonoBehaviour
{
    public GameObject button;



    public void OnPress()
    {
        if (!(GameManager.Instance.EndRoundPlayer1 || GameManager.Instance.EndRoundPlayer2))
        {
            Conffrontt(GameObject.Find("MeleeField1"), GameObject.Find("MeleeField2"));
            Conffrontt(GameObject.Find("RangeField1"), GameObject.Find("RangeField2"));
            Conffrontt(GameObject.Find("AssediumField1"), GameObject.Find("AssediumField2"));
            GameManager.Instance.ChangeTurn();
        }
    }

    public void Conffrontt(GameObject Zona1, GameObject Zona2)
    {
        if (Zona1.transform.childCount != 0 && Zona2.transform.childCount != 0)
        {
            int totalzona1 = +Zona1.GetComponentInChildren<Cards>().Attack;
            int totalzona2 = +Zona2.GetComponentInChildren<Cards>().Attack;
            int randomnumber1 = UnityEngine.Random.Range(0, Zona1.transform.childCount - 1);
            int randomnumber2 = UnityEngine.Random.Range(0, Zona2.transform.childCount - 1);

            if (totalzona1 > totalzona2)
                Zona2.transform.GetChild(randomnumber2).transform.SetParent(GameObject.Find("GravePlayer2").transform, false);
            if (totalzona1 < totalzona2)
                Zona1.transform.GetChild(randomnumber1).transform.SetParent(GameObject.Find("GravePlayer1").transform, false);
        }
    }
}
