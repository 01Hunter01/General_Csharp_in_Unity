using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyGame
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public event Action<InteractiveObject> OnDestroyChange;
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            OnDestroyChange?.Invoke(this);
            Destroy(gameObject);
        }

        protected abstract void Interaction();

        private void Start()
        {
            Action();
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}

