using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using position;
using System.IO;


public class Leader : MonoBehaviour
{
    public string Name;
    public Position.LiderEffect LiderEfects;

    //dont touch
    private Sprite DefaultSprite;


    public void Start()
    {
        DefaultSprite = GameObject.Find("ShowCard").GetComponent<Image>().sprite;
    }

    private void OnMouseDown()
    {
        
        if (GameObject.Find("ShowCard").GetComponent<Image>().sprite != gameObject.GetComponent<Image>().sprite)
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        else
            GameObject.Find("ShowCard").GetComponent<Image>().sprite = DefaultSprite;


        if (Scope.FirstExampleCard != null && LiderEfects == Position.LiderEffect.Inmune)
        {
            Scope.FirstExampleCard.GetComponent<Cards>().Afected = false;
            Debug.Log("LiderEffect");
        }
    }
}
