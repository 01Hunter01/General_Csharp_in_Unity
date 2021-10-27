using UnityEngine;

namespace MyGame
{
    public sealed class GoodBonusSpeedUp: InteractiveObject, IFly
    {
        
        private float _lengthFly;
        public Player player;


        private void Awake()
        {
           
            _lengthFly = Random.Range(1.0f, 3.0f);
            
        }

        protected override void Interaction()
        {
            player.speed *= 2.0f;
            
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
        }

        
    }
}
