using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplaySlow
    {
        private Text _slowLabel;

        public DisplaySlow(GameObject bonus)
        {
            _slowLabel = bonus.GetComponentInChildren<Text>();
            _slowLabel.text = string.Empty; 
        }

        public void Display()
        {
            _slowLabel.text = $"Your speed is decreased by 1.5";
        }
    }
}
