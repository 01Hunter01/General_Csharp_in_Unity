using System;
using UnityEngine;
using static UnityEngine.Random;

namespace MyGame
{
    public sealed class BadBonus : InteractiveObject, IRotation, IFly
    {
        private float _lengthFly;
        private float _speedRotation;
        

        public delegate void CaughtPlayerChange(string name, Color color);
        private event CaughtPlayerChange _caughtPlayer;
        public event CaughtPlayerChange CaughtPlayer
        {
            add {_caughtPlayer += value; }
            remove {_caughtPlayer -= value; }
        }

        private void Awake()
        {
            _lengthFly = Range(1.0f, 3.0f);
            _speedRotation = Range(10.0f, 70.0f);
        }

        protected override void Interaction()
        {
            _caughtPlayer?.Invoke(gameObject.name, _color);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * _speedRotation), Space.World);
            
        }
    }
}

