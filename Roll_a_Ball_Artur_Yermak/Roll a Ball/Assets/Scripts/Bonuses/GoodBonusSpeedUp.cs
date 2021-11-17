using UnityEngine;

namespace MyGame
{
    public sealed class GoodBonusSpeedUp: InteractiveObject, IFly
    {
        
        private float _lengthFly;
        private PlayerBase _player;
        private Reference _reference;

        public delegate void OnPickUpChange();
        private event OnPickUpChange _pickUpChange;
        public event OnPickUpChange PickUpChange
        {
            add { _pickUpChange += value; }
            remove { _pickUpChange -= value; }
        }
        private void Awake()
        {
            _reference = new Reference();
            _player = _reference.PlayerBall;

            _lengthFly = Random.Range(1.0f, 3.0f);
            
        }

        protected override void Interaction()
        {
            _player.speed *= 2.0f;
            _pickUpChange?.Invoke();
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
