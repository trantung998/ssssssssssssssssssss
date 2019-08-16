using Entitas;
using UnityEngine;
using View;

namespace Character
{
    public class CreateDummyCharacterSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;

        public CreateDummyCharacterSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            var character1 = _gameContext.CreateEntity();
            character1.AddViewAsset(AssetId.DummyCharacter);
            character1.AddCharacterCharacterStats(new CharacterStat()
                {armor = 10, health = 100, attackDamage = 20, criticalChance = 0.5f, criticalDamageFactor = 1.5f});

            character1.AddCharacterCharacterMetaData(1, new CharacterMetaData() {level = 1, displayName = "Dummy1"});
            character1.AddCharacterPosition(new Vector3(-1, 0));

            var character2 = _gameContext.CreateEntity();
            character2.AddViewAsset(AssetId.DummyCharacter);
            character2.AddCharacterCharacterStats(new CharacterStat()
                {armor = 10, health = 100, attackDamage = 20, criticalChance = 0.5f, criticalDamageFactor = 1.5f});

            character2.AddCharacterCharacterMetaData(2, new CharacterMetaData() {level = 1, displayName = "Dummy2"});
            character2.AddCharacterPosition(new Vector3(1, 0));
        }
    }
}