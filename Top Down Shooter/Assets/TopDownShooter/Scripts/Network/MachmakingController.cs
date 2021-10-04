using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{ 
    public enum PlayerNetworkState { offline, Connecting, Connectend, InRoom, JoinIngRoom }
    public class MachmakingController : Photon.PunBehaviour
    {
        [SerializeField] private float _delayToConnect = 3;
        public static MachmakingController Instance;
        private const string _networkVersiyon = "v1.0";
        private void Awake()
        {
            Instance = this;
        }
        IEnumerator Start()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.offline));
            yield return new WaitForSeconds(_delayToConnect);
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_networkVersiyon);
        }
        public void CreateRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoinIngRoom));
            PhotonNetwork.CreateRoom(null);
        }
        public void OnJoinRandomRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoinIngRoom));
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
        }
        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connectend));
        }
        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.offline));
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