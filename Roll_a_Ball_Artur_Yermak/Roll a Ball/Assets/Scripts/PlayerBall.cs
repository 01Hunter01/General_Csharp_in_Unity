using UnityEngine;

namespace MyGame
{
    internal sealed class PlayerBall : Player, IDisposable
    {
        

        private void FixedUpdate()
        {
            Move();
        }

        public void Dispose()
        {
            Destroy(gameObject);
            Debug.Log("I dispose a player");
        }

    }
}

