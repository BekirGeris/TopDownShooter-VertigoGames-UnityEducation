using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Invertory
{
    public class PlayerInvertoryController : MonoBehaviour
    {
        [SerializeField] private AbstractBasePlayerInvertorynItemData[] _invertoryItemDataAray;
       
        private List<AbstractBasePlayerInvertorynItemData> _instantiatedItemDataList;
        public Transform parent;
        public ReactiveCommand ReactiveShootCommand { get; private set; }

        private void Start()
        {
            InitialInvertory(_invertoryItemDataAray);
        }
        public void InitialInvertory(AbstractBasePlayerInvertorynItemData[] _invertoryItemDataAray)
        {
            if (ReactiveShootCommand != null)
            {
                //reaktif komutu ayarlama
                ReactiveShootCommand.Dispose();
            }
            ReactiveShootCommand = new ReactiveCommand();

            //eski envanteri temizlemek ve yenisini oluþturmak
            ClearInvertory();
            _instantiatedItemDataList = new List<AbstractBasePlayerInvertorynItemData>(_invertoryItemDataAray.Length);
            foreach (var _invertoryItemData in _invertoryItemDataAray)
            {
                var instantiated = Instantiate(_invertoryItemData);
                instantiated.Initialize(this);
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
