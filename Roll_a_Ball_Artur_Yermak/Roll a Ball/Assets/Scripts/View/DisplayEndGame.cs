using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        
        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"GAME OVER. You have been died by {name} with {color} color.";
        }

    }
}
