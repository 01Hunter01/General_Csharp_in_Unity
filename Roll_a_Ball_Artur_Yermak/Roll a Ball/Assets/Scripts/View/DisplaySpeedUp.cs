using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplaySpeedUp
    {
        private Text _speedUpLabel;

        public DisplaySpeedUp(GameObject bonus)
        {
            _speedUpLabel = bonus.GetComponentInChildren<Text>();
            _speedUpLabel.text = string.Empty; 
        }

        public void Display()
        {
            _speedUpLabel.text = $"Your speed is increased by 2";
        }
    }
}
