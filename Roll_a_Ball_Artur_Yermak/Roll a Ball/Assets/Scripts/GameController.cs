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
        private int _countBonuses;
        private int _maxPoints = 4;
        private Reference _reference;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(player);
            _interactiveObject.AddExecuteObject(_inputController);

            _displayWinGame = new DisplayWinGame(_reference.WinGame);
            _displayEndGame = new DisplayEndGame(_reference.Bonuse);
            _displayBonuses = new DisplayBonuses(_reference.EndGame);
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
            }
            _displayBonuses.Display(_countBonuses);
        }

        private void PickUpChange()
        {
            Debug.Log("Speedof ball is increased by 2");
        }

        private void PickUpChangeSlow()
        {
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
