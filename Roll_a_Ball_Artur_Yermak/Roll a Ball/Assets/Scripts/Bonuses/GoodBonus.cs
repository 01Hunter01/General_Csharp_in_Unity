using System;
using UnityEngine;
using static UnityEngine.Random;

namespace MyGame
{
    public sealed class GoodBonus : InteractiveObject, IFly
    {
        public int Point;
        public event Action<int> OnPointChange = delegate { };
        private float _lengthFly;
        
        

        private void Awake()
        {
            _lengthFly = Range(1.0f, 3.0f);
        }

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        
    }
}

