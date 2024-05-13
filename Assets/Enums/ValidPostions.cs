using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace position

{
    public class Position : MonoBehaviour
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
            Copy,
            RandomDestroy
        }

        public enum LiderEffect
        {
            Inmune,
            UnfairDraw
        }
    }
}
