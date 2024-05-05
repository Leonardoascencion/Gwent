using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using position;
using System.IO;

public class Cards : MonoBehaviour
{
    //    public Card Property { get; set; } tampoco se usarlo ahora mismo
    public string Name;
    public int Id = 0;
    public int Attack = 99;
    public bool Afected = true;
    public bool ItIsInHand = true;
    public List<Posiciones.CombatZone> Belongs;

    void OnMouseDown()
    {
        if (Scope.ExampleCard == this.gameObject)
            Scope.ExampleCard = null;
        else
        {
            Scope.ExampleCard = this;
        }

    }

    void OnMouseEnter()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
    }

    void OnMouseExit()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
    }
}
