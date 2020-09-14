using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace First.Services
{
    /// <summary>
    /// Helper for cache Resources.Load calls with 2x performance boost.
    /// </summary>
    sealed class CacheResourceService : MonoBehaviourService<CacheResourceService>
    {
        readonly Dictionary<string, Object> _cache = new Dictionary<string, Object>(2048);

        /// <summary>
        /// Return loaded resource from cache or load it. Important: if you request resource with one type,
        /// you cant get it for same path and different type.
        /// </summary>
        /// <param name="path">Path to loadable resource relative to "Resources" folder.</param>
        public T Load<T>(string path) where T : Object
        {
            Object asset;
            if (!_cache.TryGetValue(path, out asset))
            {
                asset = Resources.Load<T>(path);
                if (asset != null)
                {
                    _cache[path] = asset;
                }
            }

            return asset as T;
        }

        public IEnumerator<GameObject> BuildGameObject(string prefabName)
        {
            Object asset;
            if (_cache.TryGetValue(prefabName, out asset) == false)
            {
                var load = Addressables.LoadAssetAsync<GameObject>(prefabName);

                while (load.IsDone == false) yield return null;

                asset = load.Result;

                _cache.Add(prefabName, asset);
            }

            yield return (GameObject) asset;
        }

        /// <summary>
        /// Force unload resource. Use carefully.
        /// </summary>
        /// <param name="path">Path to loadable resource relative to "Resources" folder.</param>
        public void Unload(string path)
        {
            Object asset;
            if (_cache.TryGetValue(path, out asset))
            {
                _cache.Remove(path);
                Resources.UnloadAsset(asset);
            }
        }

        protected override void OnCreateService()
        {
        }

        protected override void OnDestroyService()
        {
            _cache.Clear();
        }
    }
}