using UnityEngine;

namespace MyGame
{
    public sealed class MiniMapInitialize: IExecute
    {
        private readonly Transform _owner;
        private readonly Transform _target;

        public MiniMapInitialize(Transform owner, Transform target)
        {
            _owner = owner;
            _target = target;
        }

        public void Execute()
        {
            var main = Camera.main;
            _owner.parent = null;
            _owner.rotation = Quaternion.Euler(90.0f, 0, 0);
            _owner.position = _target.position + new Vector3(0, 12.0f, 0);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            var component = _owner.GetComponent<Camera>();
            component.targetTexture = rt;
            component.depth = --main.depth;
        }
    }
}
