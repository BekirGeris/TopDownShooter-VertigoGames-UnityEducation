using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Invertory
{
    public class PlayerInvertoryController : MonoBehaviour
    {
        [SerializeField] private AbstractPlayerInvertoryItemData[] _invertoryItemDataAray;
        private void Start()
        {
            InitialInvertory(_invertoryItemDataAray);
        }

        public void InitialInvertory(AbstractPlayerInvertoryItemData[] _invertoryItemDataAray)
        {
            foreach(var _invertoryItemData in _invertoryItemDataAray)
            {
                _invertoryItemData.CreateIntoInvertory(this);
            }
        }
    }
}
