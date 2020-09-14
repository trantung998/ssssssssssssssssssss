using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace First.Services
{
    public class ResourceService
    {
        readonly Dictionary<object, GameObject> _prefabs;

        public ResourceService()
        {
            _prefabs = new Dictionary<object, GameObject>();
        }

        public IEnumerator<GameObject> GetCharacterPrefab(object key)
        {
            if (_prefabs.TryGetValue(key, out var go) == false)
            {
                var operationHandle = Addressables.LoadAssetAsync<GameObject>(key);

                while (operationHandle.IsDone == false) yield return null;

                go = operationHandle.Result;

                _prefabs.Add(key, go);
            }
            
            yield return go;
        }
    }
}