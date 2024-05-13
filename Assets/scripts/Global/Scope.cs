using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Scope : MonoBehaviour
{
    public static Cards FirstExampleCard { get; set; }
    public static Cards SecondExampleCard { get; set; }
    public static Hand CardsInHandZone { get; set; }
    /*     public static WarZone CardsInMeleeZone { get; set; }
        public static RangeZone CardsInRangeZone { get; set; } */
    public static ClimateZone ClimateZone { get; set; }
    public static GameObject TextDebugger { get; set; }

}
