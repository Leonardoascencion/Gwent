using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowBehavior : MonoBehaviour
{
    private Sprite DefaultSprite;
    public Text Name;
    public Text Attack;
    public Text Effect;
    public Text Range;

    private void Start()
    {
        DefaultSprite = gameObject.GetComponent<Image>().sprite;
    }

    private void Update()
    {
        if (Scope.FirstExampleCard != null)
        {
            gameObject.GetComponent<Image>().sprite = Scope.FirstExampleCard.GetComponent<Image>().sprite;
            Name.text = Scope.FirstExampleCard.Name;
            Attack.text = "" + Scope.FirstExampleCard.Attack;
            Effect.text = Scope.FirstExampleCard.monsterEfects.ToString();
             for (int i = 0; i <Scope.FirstExampleCard.BelongsPositiions.Count; i++)
                Range.text = "" + Scope.FirstExampleCard.BelongsPositiions[i].ToString();
 
        }
    }
}
