using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Manager/Scriptable Scene Maneger")]
    public class ScriptableSceneManager : AbstractScriptabletManager<ScriptableSceneManager>
    {
        [SerializeField] private string _menuScene;
        [SerializeField] private string _gameScene;
        public override void Initialize()
        {
            SceneManager.LoadScene(_menuScene);
            base.Initialize();
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(_compositeDisposable);
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            //when network state change
            switch (obj.PlayerNetworkState)
            {
                case PlayerNetworkState.offline:
                    break;
                case PlayerNetworkState.Connecting:
                    break;
                case PlayerNetworkState.Connectend:
                    break;
                case PlayerNetworkState.JoinIngRoom:
                    break;
                case PlayerNetworkState.InRoom:
                    SceneManager.LoadScene(_gameScene);
                    break;
                default:
                    break;
            }
        }
    }
} 