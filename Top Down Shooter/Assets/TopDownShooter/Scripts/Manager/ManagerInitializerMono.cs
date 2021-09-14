using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class ManagerInitializerMono : MonoBehaviour
    {
        [SerializeField] private AbstractBaseScriptabletManager[] _abstractBaseScriptabletManagers;
        private List<AbstractBaseScriptabletManager> _instantiateAbstractBaseScriptabletManagerList;

        public void Start()
        {
            _instantiateAbstractBaseScriptabletManagerList = new List<AbstractBaseScriptabletManager>(_abstractBaseScriptabletManagers.Length);
            foreach (var _abstractBaseScriptabletManager in _abstractBaseScriptabletManagers)
            {
                var instantiated = Instantiate(_abstractBaseScriptabletManager);
                _abstractBaseScriptabletManager.Initialize();
                _instantiateAbstractBaseScriptabletManagerList.Add(instantiated);
            }
        }

        private void OnDestroy()
        {
            if(_instantiateAbstractBaseScriptabletManagerList != null)
            {
                foreach (var _abstractBaseScriptabletManager in _abstractBaseScriptabletManagers)
                {
                    _abstractBaseScriptabletManager.Destroy();
                }
            }
        }
    }
}