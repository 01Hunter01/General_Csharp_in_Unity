using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplayWinGame
    {
        private Text _winGameLabel;
        
        public DisplayWinGame(GameObject winGame)
        {
            _winGameLabel = winGame.GetComponentInChildren<Text>();
            _winGameLabel.text = string.Empty;
        }

        public void WinGame()
        {
            _winGameLabel.text = $"You Win! Congratulations!";
        }

    }
}
