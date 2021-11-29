using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vector3Serializable Position;
        public bool IsEnabled;
        public float SpeedBall;
        //public List<InteractiveObject> bonuse;

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

        public override string ToString() => $"<color=yellow>Name</color> {Name}, <color=yellow>Position</color> {Position}, \n" +
            $"<color=yellow>IsVisible</color> {IsEnabled}, <color=yellow>Speed = </color> {SpeedBall}";
    }


    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $" (X = {X}, Y = {Y}, Z = {Z})";
        
    }

}
