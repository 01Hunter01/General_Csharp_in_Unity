using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    [Serializable]
    public sealed class SaveDataBonuses
    {

        public Transform goodBonus;
        public Transform goodBonusSpeedUp;
        public Transform badBonus;
        public Transform badBonusSlow;

        public override string ToString() => $"<color=yellow>Positions of Bonuses are loaded!</color>";

        //private List<InteractiveObject> SaveBonuses(List<InteractiveObject> interactiveObject)
        //{

        //    foreach (var b in interactiveObject)
        //    {
        //        if (b is GoodBonus) { interactiveObject.Add(b); }
        //        if (b is GoodBonusSpeedUp) { interactiveObject.Add(b); }
        //        if (b is BadBonus) { interactiveObject.Add(b); }
        //        if (b is BadBonusSlow) { interactiveObject.Add(b); }
        //    }

        //    return interactiveObject;
        //}

        //public GoodBonus goodBonus;
        //public GoodBonusSpeedUp goodBonusSpeedUp;
        //public BadBonus badBonus;
        //public BadBonusSlow badBonusSlow;
    }
}
