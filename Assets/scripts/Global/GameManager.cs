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
    public bool StartTurn { get; set; } = true;
    public bool TurnPlayer1 { get; set; } = true;
    public bool TurnPlayer2 { get; set; } = false;
    public bool EndRoundPlayer1 { get; set; } = false;
    public bool EndRoundPlayer2 { get; set; } = false;
    public bool ENDGAME { get; private set; } = false;
    public bool StartRound1 = false;
    public bool StartRound2 = false;
    public int Contador;
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
                    if (GameObject.Find("Leader2").GetComponent<Leader>().LiderEfects == EspecialHabilities.Especial.LiderEffect.UnfairDraw && GameObject.Find("Leader1").GetComponent<Leader>().LiderEfects != EspecialHabilities.Especial.LiderEffect.UnfairDraw)
                    {
                        ScorePlayer1 -= 1;
                        GameObject.Find("Text error").GetComponent<Text>().text = " Empate(guiño al 2)";
                    }
                    else
                    {
                        GameObject.Find("Text error").GetComponent<Text>().text = " Empate(guiño al 1)";
                        ScorePlayer2 -= 1;
                    }
                }
                EndRoundPlayer1 = false;
                EndRoundPlayer2 = false;
                StartRound1 = true;
                StartRound2 = true;
                DropCementery(GameObject.Find("Climate"));
                DropCementery(GameObject.Find("MeleeField1"));
                DropCementery(GameObject.Find("RangeField1"));
                DropCementery(GameObject.Find("AssediumField1"));
                DropCementery(GameObject.Find("MeleeField2"));
                DropCementery(GameObject.Find("RangeField2"));
                DropCementery(GameObject.Find("AssediumField2"));
            }
            GameObject.Find("RoundCount1").GetComponent<Text>().text = ScorePlayer1.ToString();
            GameObject.Find("RoundCount2").GetComponent<Text>().text = ScorePlayer2.ToString();
        }

        if (ScorePlayer1 == 2 && ScorePlayer2 < 2)
        {
            GameObject.Find("Text error").GetComponent<Text>().text = "Gano Player1";
            ENDGAME = true;
            Debug.Log("Gano1");
        }

        if (ScorePlayer2 == 2 && ScorePlayer1 < 2)
        {
            GameObject.Find("Text error").GetComponent<Text>().text = "Gano Player2";
            ENDGAME = true;
            Debug.Log("Gano2");
        }

        if (ScorePlayer1 == 2 && ScorePlayer2 == 2)
        {
            GameObject.Find("Text error").GetComponent<Text>().text = "Gano Player2";
            ENDGAME = true;
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
    public void ChangeTurn()
    {
        Instance.TurnPlayer1 = !Instance.TurnPlayer1;
        Instance.TurnPlayer2 = !Instance.TurnPlayer2;
        StartTurn = true;
    }


}