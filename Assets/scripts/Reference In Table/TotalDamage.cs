using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 // script asociate to count the total damage of the zones of the player in the table
public class TotalDamage : MonoBehaviour
{
    public GameObject Total;
    public GameObject Melee;
    public GameObject Range;
    public GameObject Assedium;
    int sum;

    void Start()
    {
        Total.GetComponent<Text>().text = "0";
    }
    void Update()
    {
        sum = 0;
        sum = Convert(Melee.GetComponent<Text>().text) +
        Convert(Range.GetComponent<Text>().text) +
        Convert(Assedium.GetComponent<Text>().text);
        Total.GetComponent<Text>().text = "" + sum;

    }

    int Convert(string texto)
    {
        int numero;
        if (int.TryParse(texto, out numero))
            return numero;
        else
            return 0;

    }

}
