using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public sealed class GameController: MonoBehaviour, IDisposable
    {
        public Text finishGameLabel;
        public Camera mainCamera;
        private Animation _shake;
        private InteractiveObject[] _interactiveObjects;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _shake = mainCamera.GetComponent<Animation>();
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _displayEndGame = new DisplayEndGame(finishGameLabel);
            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;                
                }
                if (o is GoodBonusSpeedUp goodBonusSpeedUp)
                {
                    goodBonusSpeedUp.PickUpChange += PickUpChange;
                }
            }
        }

        private void CaughtPlayer(object value)
        {
            Time.timeScale = 0.0f;
        }

        private void PickUpChange()
        {
            _shake.Play("ShakeCamera");
            //Vector3 cameraDefaultPos = mainCamera.transform.position;
            //Vector3 cameraChangePos = new Vector3(cameraDefaultPos.x + Mathf.PingPong(Time.time, 15.0f), cameraDefaultPos.y + Mathf.PingPong(Time.time, 10.0f), cameraDefaultPos.z);
            //mainCamera.transform.position = cameraChangePos;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveobject = _interactiveObjects[i];

                if (interactiveobject == null)
                {
                    continue;
                }

                if (interactiveobject is IFly fly)
                {
                    fly.Fly();
                }

                if(interactiveobject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if(interactiveobject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

       
        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if(o is InteractiveObject interactiveObject)
                {
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                    if (o is GoodBonusSpeedUp goodBonusSpeedUp)
                    {
                        goodBonusSpeedUp.PickUpChange -= PickUpChange;
                    }
                    Destroy(interactiveObject.gameObject);
                }
                

            }
        }

    }
}
