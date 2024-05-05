using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextZone : MonoBehaviour
{
    public GameObject Texto;

    void Start()
    {
        Texto.GetComponent<Text>().text = "Todo bien";

        Scope.TextDebugger = this.gameObject;
        Scope.TextDebugger.GetComponent<Text>().text = "Estoy duro";
    }
}
