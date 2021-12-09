using UnityEngine;

namespace MyGame
{
    public sealed class MiniMapController: IExecute
    {
        private readonly Transform _owner;
        private readonly Transform _target;

        public MiniMapController(Transform owner, Transform target)
        {
            _owner = owner;
            _target = target;
        }

        public void Execute()
        {
            var newPosition = _target.position;
            newPosition.y = _owner.position.y;
            _owner.position = newPosition;
            _owner.rotation = Quaternion.Euler(90, _target.eulerAngles.y, 0);
        }

    }
}
