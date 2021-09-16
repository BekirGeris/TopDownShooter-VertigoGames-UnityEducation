using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Invertory
{
    public abstract class AbstractBasePlayerInvertorynItemData : ScriptableObject
    {
        private PlayerInvertoryController _playerInvertoryController;
        protected CompositeDisposable _compositeDisposable;
        public virtual void Initialize(PlayerInvertoryController playerInvertory)
        {
            _playerInvertoryController = playerInvertory;
            _compositeDisposable = new CompositeDisposable();
        }
        public virtual void Destroy()
        {
            //buna sat�r t�m etkinliklerin aboneli�inden ��kt���m�z anlam�na gelir
            _compositeDisposable.Dispose();
            Destroy(this);
        }
    }
}