using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyGame
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected Color _color;

        private bool _isInterectable;
        protected bool IsInteractable
        {
            get { return _isInterectable; }
            private set
            {
                _isInterectable = value;
                GetComponent<Renderer>().enabled = _isInterectable;
                GetComponent<Collider>().enabled = _isInterectable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
            //Destroy(gameObject);
        }

        protected abstract void Interaction();
        public abstract void Execute();


        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        
    }
}

