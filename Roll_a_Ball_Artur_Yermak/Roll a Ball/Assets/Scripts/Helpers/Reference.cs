using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Camera _miniMapCamera;
        private GameObject _bonuse;
        private GameObject _endGame;
        private GameObject _winGame;
        private Canvas _canvas;
        private Button _restartButton;

        public PlayerBall PlayerBall
        {
            get
            {
                if(_playerBall == null)
                {
                    var gameobject = Resources.Load<PlayerBall>("PlayerBall");
                    _playerBall = Object.Instantiate(gameobject);
                }

                return _playerBall;
            }
        }

        public Camera MiniMapCamera
        {
            get
            {
                if (_miniMapCamera == null)
                {
                    var gameobject = Resources.Load<Camera>("MiniMap/MiniMapCamera");
                    _miniMapCamera = Object.Instantiate(gameobject);
                }

                return _miniMapCamera;

            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;

            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonuse
        {
            get
            {
                if (_bonuse == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuse = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _bonuse;
            }
        }
        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }

        public GameObject WinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/WinGame");
                    _winGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _winGame;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }
            
        
    }
}
