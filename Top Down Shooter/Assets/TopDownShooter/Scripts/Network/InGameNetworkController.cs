using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkController : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private void Start()
        {
            InstantiateLocalPlayer();
        }
        public void InstantiateLocalPlayer()
        {
            var instantiate = Instantiate(_localPlayerPrefab);
            instantiate.SetOwnership(PhotonNetwork.player);
            photonView.RPC("APC_InstantiateLocalPlayer", PhotonTargets.OthersBuffered);
            PhotonNetwork.isMessageQueueRunning = true;
        }
        [PunRPC]
        public void APC_InstantiateLocalPlayer(PhotonMessageInfo photonMessageInfo)
        {
            var instantiate = Instantiate(_remotePlayerPrefab);
            instantiate.SetOwnership(photonMessageInfo.sender);
        }
    }
}