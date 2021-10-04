using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using TMPro;

namespace TopDownShooter.UI
{ 
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentState;

        private void Awake()
        {
            _currentState.text = "Connecting";
            _currentState.color = Color.red;
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerOnline);
        }
        private void OnPlayerOnline(EventPlayerNetworkStateChange obj)
        {
            _currentState.text = "Connected";
            _currentState.color = Color.blue;
        }
        public void _CreateRoomClick()
        {

        }
        public void _JoinRandomRoomClick()
        {

        }
        public void _SettingsClick()
        {

        }
    }
}