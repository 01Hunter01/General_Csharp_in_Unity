using System;
using UnityEngine;
using static UnityEngine.Random;

namespace MyGame
{
    public sealed class BadBonusSlow : InteractiveObject, IRotation, IFlicker
    {
        
        public delegate void OnPickUpChangeSlow();
        private event OnPickUpChangeSlow _pickUpChangeSlow;
        public event OnPickUpChangeSlow PickUpChangeSlow
        {
            add { _pickUpChangeSlow += value; }
            remove { _pickUpChangeSlow -= value; }
        }
        private Material _material;
        private float _speedRotation;
        

        private void Awake()
        {
            

            _material = GetComponent<Renderer>().material;
            _speedRotation = Range(10.0f, 70.0f);
        }

        protected override void Interaction()
        {
            _pickUpChangeSlow?.Invoke();
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Flicker();
            Rotation();
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));

        }

        public void Rotation()
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * _speedRotation), Space.World);
            
        }
    }
}

