using System.Collections.Generic;
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
            character1.AddCharacterCharacterStats(new List<BaseStat>());
            character1.AddCharacterCharacterMetaData(1,
                new CharacterMetaData() {level = 1, displayName = "Dummy1", teamId = 0});
            character1.AddCharacterPosition(new Vector3(-1, 0));
            AddCharacterStat(character1, CharacterType.Creep, 1);


            var character2 = _gameContext.CreateEntity();
            character2.AddViewAsset(AssetId.DummyCharacter);
            character2.AddCharacterCharacterStats(new List<BaseStat>());

            character2.AddCharacterCharacterMetaData(2,
                new CharacterMetaData() {level = 1, displayName = "Dummy2", teamId = 1});
            
            character2.AddCharacterPosition(new Vector3(1, 0));
            character2.AddCharacterMovement(0.5f, Vector2.right);
            character2.AddBT(new DummyEnemyBehaviourTree());
            AddCharacterStat(character2, CharacterType.Creep, 1);
        }

        //todo: đọc từ config, tính toán theo level, items, ...
        private void AddCharacterStat(GameEntity characterEntity, CharacterType characterType, int level)
        {
            if (characterEntity.hasCharacterCharacterStats)
            {
                characterEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.MaxHp, 550));
                characterEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.Damage, 45));
                characterEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.Armor, 20));
            }
        }
    }
}