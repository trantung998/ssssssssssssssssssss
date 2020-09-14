using System.Collections;
using First.Descriptors;
using First.EntityStructs;
using First.Services;
using SpawnData;
using Svelto.ECS;
// using Svelto.ECS.First.Descriptors;
using Svelto.ECS.Hybrid;
using Svelto.ObjectPool;
using UnityEngine;

namespace First.Factories
{
    public class CharacterFactory
    {
        private readonly ResourceService _resourceService;
        private readonly IEntityFactory _entityFactory;
        private GameObjectPool _gameObjectPool;

        public CharacterFactory(ResourceService resourceService, IEntityFactory entityFactory)
        {
            _resourceService = resourceService;
            _entityFactory = entityFactory;
            _gameObjectPool = new GameObjectPool();
        }

        public IEnumerator Build(CharacterSpawnData characterSpawnData)
        {
            var prefab = _resourceService.GetCharacterPrefab(characterSpawnData.prefabName);
            yield return prefab;
            GameObject characterGameObject = _gameObjectPool.Use<GameObject>(characterSpawnData.prefabName, () => { return GameObject.Instantiate(prefab.Current); });


            var implementors = characterGameObject.GetComponentsInChildren<IImplementor>();
            var initializer = _entityFactory.BuildEntity<CharacterEntityDescriptor>(new EGID((uint) characterGameObject.GetInstanceID(), ECSGroups.ActiveCharacter), implementors);

            initializer.Init(new CharacterHealthComponent() {HealthValue = 50, MaxHealthValue = 100});
            initializer.Init(new MovementComponent() {Direction = Vector3.right, Speed = 2f, Acceleration = Vector3.zero});
            initializer.Init(new SteeringComponent() {destination = Vector3.one * 10f, maxSteeringForce = 0.2f});

            var transform = characterGameObject.transform;
            transform.position = characterSpawnData.spawnPoint;
        }

        public void Preallocate()
        {
            _entityFactory.PreallocateEntitySpace<CharacterEntityDescriptor>(ECSGroups.ActiveCharacter, 10);
        }
    }
}