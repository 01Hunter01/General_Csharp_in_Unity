using UnityEditor;
using UnityEngine;

namespace MyGame
{
    [CustomEditor(typeof(GoodBonus))]
    public class GoodBonusEditor : UnityEditor.Editor
    {
        private bool _isPressButtonView;
        private bool _isPressButtonNotView;
        private bool _isEnabled = false;
        

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GoodBonus bonuse = (GoodBonus)target;

            var light = bonuse.gameObject.GetComponent<Light>();

            light.enabled = _isEnabled;

            _isPressButtonView = GUILayout.Button("View Point", EditorStyles.miniButton);
            _isPressButtonNotView = GUILayout.Button("Hide Point", EditorStyles.miniButton);

            if (_isPressButtonView && light)
            {
                _isEnabled = true;
                light.enabled = _isEnabled;
            }
            
            if (_isPressButtonNotView && light)
            {
                _isEnabled = false;
                light.enabled = _isEnabled;
            }

            
        }
        
    }
}
