using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Scope : MonoBehaviour
{
    public static Cards ExampleCard { get; set; }
    public static GameObject BoxCard { get; set; }
    public static Hand CardsInHandZone { get; set; }
/*     public static WarZone CardsInMeleeZone { get; set; }
    public static RangeZone CardsInRangeZone { get; set; } */
    public static GraveZone CardsInGraveZone { get; set; }
    public static bool BelongToMelee { get; set; }
    public static bool BelongToRange { get; set; }
    public static bool BelongToAssault { get; set; }
    public static GameObject TextDebugger { get; set; }
}
