using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace MyGame
{
    public class MyWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public static Material Material;
        public string _nameobject = "Trap";
        public bool _groupEnabled;
        public float _width = 1;
        public float _height = 1;
        public float _length = 1;
        public float _posX = 0;
        public float _posY = 0;
        public float _posZ = 0;

        private Stack<Transform> _stackRoot = new Stack<Transform>();

        private void OnGUI()
        {
            GUILayout.Label("Basic Options", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Input trap object", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            Material = EditorGUILayout.ObjectField("Input Material", Material, typeof(Material), true) as Material;

            _nameobject = EditorGUILayout.TextField("Object Name", _nameobject);
            _posX = EditorGUILayout.Slider("PosX", _posX, -50, 0);
            _posY = EditorGUILayout.Slider("PosY", _posY, 0, 7);
            _posZ = EditorGUILayout.Slider("PosZ", _posZ, -50, 0);
           

            _groupEnabled = EditorGUILayout.BeginToggleGroup("Additional properties", _groupEnabled);
            _width = EditorGUILayout.Slider("Width", _width, 1, 10);
            _height = EditorGUILayout.Slider("Height", _height, 1, 10);
            _length = EditorGUILayout.Slider("Length", _length, 1, 10);
            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Create Trap");

            if (button)
            {
                if(ObjectInstantiate && Material)
                {
                    GameObject root = new GameObject("Traps");
                    _stackRoot.Push(root.transform);

                    ObjectInstantiate.transform.localScale = new Vector3(_width, _height, _length);

                    Vector3 pos = new Vector3(_posX, _posY, _posZ);

                    GameObject trap = Instantiate(ObjectInstantiate, pos, Quaternion.identity);

                    SetObjectDirty(trap.gameObject);

                    trap.name = _nameobject + "(" + 1 + ")";
                    trap.transform.parent = root.transform;
                    var trapRender = trap.GetComponent<Renderer>();
                    if (trapRender)
                    {
                        trapRender.material = Material;
                    }
                }
            }


            bool destroyRoot = false;
            if(_stackRoot.Count > 0)
            {
                destroyRoot = GUILayout.Button("Remove Trap");
            }

            if (destroyRoot)
            {
                DestroyImmediate(_stackRoot.Pop().gameObject);
            }


        }

        public void SetObjectDirty(GameObject obj)
        {
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(obj);
                EditorSceneManager.MarkSceneDirty(obj.scene);
            }
        }

    }

}
