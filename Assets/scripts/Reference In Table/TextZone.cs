using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    //Script asociate to the front text that say the current  turn belong and the round and game winner
public class TextZone : MonoBehaviour
{
    public GameObject Texto;
    void Start()
    {
        Texto.GetComponent<Text>().text = "Todo bien";

        Scope.TextDebugger = gameObject;
        Scope.TextDebugger.GetComponent<Text>().text = "Estoy duro";
    }
    private void Update()
    {
        if (GameManager.Instance.ENDGAME == false)
        {
            if (GameManager.Instance.TurnPlayer1)
                Texto.GetComponent<Text>().text = "JuegaPlayer1";

            if (GameManager.Instance.TurnPlayer2)
                Texto.GetComponent<Text>().text = "JuegaPlayer2";
        }

    }
}
