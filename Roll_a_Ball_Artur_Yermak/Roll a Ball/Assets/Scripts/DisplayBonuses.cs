using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class DisplayBonuses
    {
        private Text _text;

        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value} очко(-а)";
        }
    }
}
