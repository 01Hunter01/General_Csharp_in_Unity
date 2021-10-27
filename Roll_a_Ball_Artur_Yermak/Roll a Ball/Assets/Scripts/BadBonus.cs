using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame
{
    public sealed class BadBonus : InteractiveObject, IRotation, IFlicker
    {
        private Material _material;
        private float _speedRotation;
        public GameObject player;
        

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _speedRotation = Random.Range(10.0f, 70.0f);
        }

        protected override void Interaction()
        {
           
            if (player != null)
            {
                Destroy(player);
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
                

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

