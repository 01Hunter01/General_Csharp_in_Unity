using UnityEngine;

namespace MyGame
{
    public sealed class GoodBonus : InteractiveObject, IFly
    {
        
        private float _lengthFly;
        private DisplayBonuses _displayBonuses;
        

        private void Awake()
        {
            
            _lengthFly = Random.Range(1.0f, 3.0f);
            _displayBonuses = new DisplayBonuses();
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        
    }
}

