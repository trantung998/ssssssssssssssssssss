using Entitas;
using UnityEngine;

namespace View
{
    public class UnityViewService : IViewService
    {
        private Transform _transformParent;

        public void CreateView(Contexts contexts, IEntity entity)
        {
            if (_transformParent == null)
            {
                _transformParent = new GameObject("Game Play Root View").transform;
                _transformParent.position = Vector3.zero;
            }

            var gameEntity = (GameEntity) entity;
            if (gameEntity.hasViewAsset)
            {
                var assetId = gameEntity.viewAsset.value;

                var viewObject = ObjectPool.Spawn("Prefabs/" + assetId.ToString());
                if (viewObject == null)
                {
                    entity.Destroy();
                    return;
                }

                viewObject.transform.SetParent(_transformParent);
                viewObject.transform.position = gameEntity.characterPosition.value;

                var viewController = viewObject.GetComponent<IViewController>();
                if (viewController != null)
                {
                    gameEntity.AddViewCharacterView(viewController);
                    viewController.InitializeView(contexts, entity);
                }
            }
        }
    }
}