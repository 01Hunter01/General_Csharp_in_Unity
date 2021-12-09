using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplayBonuses
    {
        private Text _bonuseLabel;

        public DisplayBonuses(GameObject bonus)
        {
            _bonuseLabel = bonus.GetComponentInChildren<Text>();
            _bonuseLabel.text = string.Empty; 
        }

        public void Display(int value)
        {
            _bonuseLabel.text = $"You get {value} point(s). Collect 4 points for Win!";
        }
    }
}
