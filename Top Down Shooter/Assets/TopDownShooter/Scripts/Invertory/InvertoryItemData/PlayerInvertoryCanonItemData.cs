using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Invertory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Invertory/Player Invertory Conan Data")]
    public class PlayerInvertoryCanonItemData : AbstractPlayerInvertoryItemData<PlayerInvertoryCanonItemMono>
    {
        [SerializeField] private float _damege;
        public float Damage { get { return _damege; } }
        [SerializeField] private float _rpm = 1f;
        public float Rpm { get { return _rpm; } }
        private float _lastShootTime;
        public override void Initialize(PlayerInvertoryController playerInvertory)
        {
            base.Initialize(playerInvertory);
            playerInvertory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand).AddTo(_compositeDisposable);
            InstalLiateAndInitialPrefab(playerInvertory.CanonParent);
            Debug.Log("Canon");
        }
        public override void Destroy()
        {
            base.Destroy();
        }
        private void OnReactiveShootCommand(Unit obj)
        {
            Debug.Log("Reactive command shoot");
            Shoot();
        }
        public void Shoot()
        {
            if(Time.time - _lastShootTime >= _rpm)
            {
            _instantiated.Shoot();
            _lastShootTime = Time.time;
            }
            else
            {
                Debug.Log("You cant shoot now");
            }
            
        }
    }
}