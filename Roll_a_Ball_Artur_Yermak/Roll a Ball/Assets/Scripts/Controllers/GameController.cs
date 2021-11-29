using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyGame
{
    public sealed class GameController: MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;

        private DisplayWinGame _displayWinGame;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;

        private CameraController _cameraController;
        private InputController _inputController;
        private MiniMapController _miniMapController;
        private MiniMapInitialize _miniMapInitialize;

        private int _countBonuses;
        private int _maxPoints = 4;
        private Reference _reference;
        private PlayerBase _player = null;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            
            if (PlayerType == PlayerType.Ball)
            {
                _player = _reference.PlayerBall;
            }

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_player);
            _interactiveObject.AddExecuteObject(_inputController);

            _miniMapController = new MiniMapController(_reference.MiniMapCamera.transform, _player.transform);
            _interactiveObject.AddExecuteObject(_miniMapController);

            _miniMapInitialize = new MiniMapInitialize(_reference.MiniMapCamera.transform, _player.transform);
            _interactiveObject.AddExecuteObject(_miniMapInitialize);

            _displayWinGame = new DisplayWinGame(_reference.WinGame);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;                
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                }
                if (o is GoodBonusSpeedUp goodBonusSpeedUp)
                {
                    goodBonusSpeedUp.PickUpChange += PickUpChange;
                }
                if (o is BadBonusSlow badBonusSlow)
                {
                    badBonusSlow.PickUpChangeSlow += PickUpChangeSlow;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string name, Color color)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            if (_countBonuses == _maxPoints)
            {
                _displayWinGame.WinGame();
                _reference.RestartButton.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
            _displayBonuses.Display(_countBonuses);
        }

        private void PickUpChange()
        {
            _player.speed *= 2.0f;
            Debug.Log("Speed of ball is increased by 2");
        }

        private void PickUpChangeSlow()
        {
            _player.speed /= 1.5f;
            Debug.Log("Speed of ball is decreased by 1.5");
        }
        

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveobject = _interactiveObject[i];

                if (interactiveobject == null)
                {
                    continue;
                }
                interactiveobject.Execute();
            }
        }

       

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= CaughtPlayer;
                    badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
                if (o is GoodBonusSpeedUp goodBonusSpeedUp)
                {
                    goodBonusSpeedUp.PickUpChange -= PickUpChange;
                }
                if (o is BadBonusSlow badBonusSlow)
                {
                    badBonusSlow.PickUpChangeSlow -= PickUpChangeSlow;
                }
            }
        }

    }
}
