using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public class PlayerInvertoryController : MonoBehaviour
    {
        [SerializeField] private AbstractBasePlayerInvertorynItemData[] _invertoryItemDataAray;
        private List<AbstractBasePlayerInvertorynItemData> _instantiatedItemDataList;

        public Transform parent;
        private void Start()
        {
            InitialInvertory(_invertoryItemDataAray);
        }
        public void InitialInvertory(AbstractBasePlayerInvertorynItemData[] _invertoryItemDataAray)
        {
            ClearInvertory();
            _instantiatedItemDataList = new List<AbstractBasePlayerInvertorynItemData>(_invertoryItemDataAray.Length);

            foreach(var _invertoryItemData in _invertoryItemDataAray)
            {
                var instantiated = Instantiate(_invertoryItemData);
                _invertoryItemData.CreateIntoInvertory(this);
                _instantiatedItemDataList.Add(instantiated);
            }
        }
        public void ClearInvertory()
        {
            if(_instantiatedItemDataList != null)
            {
                foreach (var _createItemData in _instantiatedItemDataList)
                {
                    _createItemData.Destroy();
                }
            }
        }
        private void OnDestroy()
        {
            ClearInvertory();
        }
    }
}
