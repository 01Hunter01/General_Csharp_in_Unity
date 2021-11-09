using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        
        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(object o)
        {
            _finishGameLabel.text = $"GAME OVER";
        }

    }
}
