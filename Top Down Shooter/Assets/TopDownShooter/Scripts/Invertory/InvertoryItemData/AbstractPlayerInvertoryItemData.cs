using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public enum InvertoryItemDataType { Canon, Body}
    public abstract class AbstractPlayerInvertoryItemData<T> : AbstractBasePlayerInvertorynItemData where T : AbstractPlayerInvertoryItemMono
    {
        [SerializeField] protected string _itemId;
        [SerializeField] protected InvertoryItemDataType _invertoryItemDataType;
        [SerializeField] protected T _prefab;
        [SerializeField] protected T _instantiated;
        protected T InstalLiateAndInitialPrefab(Transform parent)
        {
            _instantiated = Instantiate(_prefab, parent);
            return _instantiated;
        }
    }
}
