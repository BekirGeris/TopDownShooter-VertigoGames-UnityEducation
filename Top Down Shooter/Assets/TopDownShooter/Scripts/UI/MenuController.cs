using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using TMPro;
using UnityEngine.UI;

namespace TopDownShooter.UI
{ 
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentState;
        [SerializeField] private List<Button> _networksButtons;
        private void Awake()
        {
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState);
        }
        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            _currentState.text = "Connection state: " + obj.PlayerNetworkState.ToString();
            foreach (Button buton in _networksButtons)
            {
                buton.interactable = obj.PlayerNetworkState == PlayerNetworkState.Connectend;
            }
            //_currentState.color = Color.blue;
        }
        public void _CreateRoomClick()
        {
            MachmakingController.Instance.CreateRoom();
        }
        public void _JoinRandomRoomClick()
        {
            MachmakingController.Instance.OnJoinRandomRoom();
        }
        public void _SettingsClick()
        {
            Debug.LogError("not ready yet");
        }
    }
}