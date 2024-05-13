using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public Button End;
    public bool BelongsPlayer1;


    public void EndRound()
    {
        if (GameManager.Instance.TurnPlayer1 && BelongsPlayer1)
        {
            GameManager.Instance.EndRoundPlayer1 = true;
            Debug.Log("Se acabo la ronda al 1");
        }

        if (GameManager.Instance.TurnPlayer2 && !BelongsPlayer1)
        {
            GameManager.Instance.EndRoundPlayer2 = true;
            Debug.Log("Se acabo la ronda al 2");
        }
    }
}
