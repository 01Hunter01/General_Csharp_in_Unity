using UnityEngine;


namespace MyGame
{
    internal sealed class CameraController : MonoBehaviour
    {
        public Player player;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = player.transform.position + _offset;
        }

    }
}

