using UnityEngine;

namespace MyGame
{
    public sealed class GameController: MonoBehaviour, IDisposable
    {
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveobject = _interactiveObjects[i];

                if (interactiveobject == null)
                {
                    continue;
                }

                if (interactiveobject is IFly fly)
                {
                    fly.Fly();
                }

                if(interactiveobject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if(interactiveobject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }


        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);

            }
        }

    }
}
