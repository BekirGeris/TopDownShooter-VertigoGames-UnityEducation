using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{ 
    public enum PlayerNetworkState { offline, Connecting, Connectend, InRoom }
    public class MachmakingController : Photon.PunBehaviour
    {
        [SerializeField] private float _delayToConnect = 3;
        public static MachmakingController Instance;
        private const string _networkVersiyon = "v1.0";
        private void Awake()
        {
            Instance = this;
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_networkVersiyon);
        }
        IEnumerator Start()
        {
            yield return new WaitForSeconds(_delayToConnect);
        }
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null);
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connectend));
            Debug.Log("On Connected To Master"); 
        }
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("ON JOÝNED LOBBY");   
        }
    }
}