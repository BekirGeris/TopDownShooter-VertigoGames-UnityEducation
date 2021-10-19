using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private List<PhotonView> _photonViewForOwnership;
        public void SetOwnership(PhotonPlayer photonPlayer)
        {
            foreach(var photonView in _photonViewForOwnership)
            {
                photonView.TransferOwnership(photonPlayer);
            }
        }
    }
}
