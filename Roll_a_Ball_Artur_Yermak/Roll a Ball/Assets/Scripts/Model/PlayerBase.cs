using UnityEngine;


namespace MyGame
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float speed = 3.0f;
        
        public abstract void Move(float x, float y, float z);
    }

}
