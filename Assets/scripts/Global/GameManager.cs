using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int AttakPlayer1 { get; set; } = 0;
    public int AttakPlayer2 { get; set; } = 0;
    public int ScorePlayer1 { get; set; } = 0;
    public int ScorePlayer2 { get; set; } = 0;
    public bool TurnPlayer1 { get; set; } = true;
    public bool TurnPlayer2 { get; set; } = false;
    public bool EndRoundPlayer1 { get; set; } = false;
    public bool EndRoundPlayer2 { get; set; } = false;
    public bool ENDGAME { get; private set; } = false;

    void Awake()
    {
        Instance = this;
        //  DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!ENDGAME)
        {
            if (EndRoundPlayer1 && !EndRoundPlayer2)
            {
                TurnPlayer1 = false;
                TurnPlayer2 = true;
            }

            if (EndRoundPlayer2 && !EndRoundPlayer1)
            {
                TurnPlayer1 = true;
                TurnPlayer2 = false;
            }

            if (EndRoundPlayer1 && EndRoundPlayer2)
            {
                if (!(Instance.TurnPlayer1 || Instance.TurnPlayer2))
                    GameObject.Find("Text error").GetComponent<Text>().text = "Nadie juega";

                TurnPlayer1 = false;
                TurnPlayer2 = false;

                AttakPlayer1 += int.Parse(GameObject.Find("Total DamagePlayer1").GetComponent<Text>().text);
                AttakPlayer2 += int.Parse(GameObject.Find("Total DamagePlayer2").GetComponent<Text>().text);


                if (AttakPlayer1 > AttakPlayer2)
                {
                    GameObject.Find("Text error").GetComponent<Text>().text = " Gana Player 1";
                    ScorePlayer1 += 1;
                    TurnPlayer1 = true;
                }

                if (AttakPlayer1 < AttakPlayer2)
                {
                    GameObject.Find("Text error").GetComponent<Text>().text = " Gana Player 2";
                    ScorePlayer2 += 1;
                    TurnPlayer2 = true;
                }

                if (AttakPlayer1 == AttakPlayer2)
                {
                    GameObject.Find("Text error").GetComponent<Text>().text = " Empate";
                    ScorePlayer1 += 1;
                    ScorePlayer2 += 1;
                    TurnPlayer2 = true;
                }
                EndRoundPlayer1 = false;
                EndRoundPlayer2 = false;
                DropCementery(GameObject.Find("Climate"));
                DropCementery(GameObject.Find("MeleeField1"));
                DropCementery(GameObject.Find("RangeField1"));
                DropCementery(GameObject.Find("AssediumField1"));
                DropCementery(GameObject.Find("MeleeField2"));
                DropCementery(GameObject.Find("RangeField2"));
                DropCementery(GameObject.Find("AssediumField2"));
            }


        }

        if (ScorePlayer1 == 2)
        {
            GameObject.Find("Text error").GetComponent<Text>().text = "Gano Player1";
            ENDGAME = true;
            Debug.Log("Gano1");
        }

        if (ScorePlayer2 == 2)
        {
            GameObject.Find("Text error").GetComponent<Text>().text = "Gano Player2";
            ENDGAME = true;
            Debug.Log("Gano2");
        }

    }

    //Function for send all cards to cementary of a zone
    public void DropCementery(GameObject Parent)
    {
        int Total = Parent.transform.childCount;
        for (int i = Total - 1; i > 0; i--)
        {
            if (Parent.transform.GetChild(i).GetComponent<Cards>().BelongsPlayer1)
                Parent.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer1").transform, false);
            else
                Parent.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer2").transform, false);

        }
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            if (Parent.transform.GetChild(i).GetComponent<Cards>().BelongsPlayer1)
                Parent.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer1").transform, false);
            else
                Parent.transform.GetChild(i).SetParent(GameObject.Find("GravePlayer2").transform, false);
        }

    }

}