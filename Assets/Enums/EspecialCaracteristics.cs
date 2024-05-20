using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace EspecialHabilities

{
    public class Especial : MonoBehaviour
    {
        public enum CombatZone
        {
            MeleeZone,
            RangeZone,
            AssediumZone,
            Target,
            Buff,
            Debuf,
            Clear,
            Leader
        }

        public enum MonsterEffect
        {
            None,
            BoostTypeA,
            BoostTypeB,
            ReInvoke,
            Inmune,
            BossDestroy,
            Draw,
            EstupidEliminate,
            Suicide
        }

        public enum LiderEffect
        {
            Inmune,
            UnfairDraw
        }
    }
}
