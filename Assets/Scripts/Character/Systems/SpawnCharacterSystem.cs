using System.Collections.Generic;
using Character;
using Entitas;
using UnityEngine;
using View;

public class SpawnCharacterSystem : IExecuteSystem
{
    private IGroup<InputEntity> spawnCharacterCommandGroup;
    private IGroup<GameEntity> characterGroup;
    private GameContext _gameContext;

    private HashSet<int>[] ids;
    private int[] idCount;

    private int numberIdCount = 1 << 5;
    private int numberIdCountPerTeam;

    public SpawnCharacterSystem(Contexts contexts)
    {
        ids = new HashSet<int>[] {new HashSet<int>(), new HashSet<int>()};
        idCount = new int[] {0, 0};
        numberIdCountPerTeam = numberIdCount >> 1;
        _gameContext = contexts.game;
        spawnCharacterCommandGroup = contexts.input.GetGroup(InputMatcher.SpawnCharacter);

        characterGroup = contexts.game.GetGroup(GameMatcher.CharacterCharacterMetaData);
        characterGroup.OnEntityRemoved += OnCharacterRemoved;
    }

    private void OnCharacterRemoved(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
    {
        RemoveUid(entity.characterCharacterMetaData.value.teamId, entity.characterCharacterMetaData.id);
    }

    public void Execute()
    {
        if (spawnCharacterCommandGroup.count > 0)
        {
            foreach (var inputEntity in spawnCharacterCommandGroup.GetEntities())
            {
                var spawnCharacterData = inputEntity.spawnCharacter.value;
                var id = GetNewId(spawnCharacterData.teamId);
                if (id >= 0)
                {
                    var characterEntity = _gameContext.CreateEntity();
                    characterEntity.AddViewAsset(AssetId.Knight_01);

                    characterEntity.AddCharacterCharacterMetaData(id,
                        new CharacterMetaData()
                        {
                            level = spawnCharacterData.level, displayName = "Dummy" + id,
                            teamId = spawnCharacterData.teamId
                        });

                    characterEntity.AddCharacterPosition(spawnCharacterData.Position);
                    characterEntity.AddCharacterMovement(0f, Vector2.right);
                    characterEntity.AddCharacterState(new CharacterStateData()
                        {currentState = CharacterState.Idle, prevState = CharacterState.None});
                    characterEntity.AddBT(new BaseCharacterBT());

                    AddCharacterStat(characterEntity, CharacterType.Creep, spawnCharacterData.level);
                }

                inputEntity.isEntityDestroyed = true;
            }
        }
    }

    //todo: đọc từ config, tính toán theo level, items, ...
    private void AddCharacterStat(GameEntity characterEntity, CharacterType characterType, int level)
    {
        var characterStatEntity = _gameContext.CreateEntity();
        characterStatEntity.AddCharacterCharacterStats(characterEntity.characterCharacterMetaData.id, 0,
            new List<BaseStat>());

        characterStatEntity.characterCharacterStats.characterId = characterEntity.characterCharacterMetaData.id;
        characterStatEntity.characterCharacterStats.retainCount += 1;

        characterStatEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.Hp, 550));
        characterStatEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.Damage, 45));
        characterStatEntity.characterCharacterStats.AddOrReplaceStat(new BaseStat(CharacterStatId.Armor, 20));
    }

    private int GetNewId(int teamId)
    {
        if (ids[teamId].Count + 1 > numberIdCountPerTeam)
        {
            Debug.Log("Het slot");
            return -1; //hết slot
        }

        int uidRtn = -1;
        int maxLoop = numberIdCountPerTeam;

        while (uidRtn == -1 && maxLoop > 0)
        {
            int uidCandidate = idCount[teamId] * 2 + teamId;
            if (!ids[teamId].Contains(uidCandidate))
            {
                ids[teamId].Add(uidCandidate);
                uidRtn = uidCandidate;
            }

            idCount[teamId] += 1;
            if (idCount[teamId] >= numberIdCountPerTeam)
            {
                idCount[teamId] = 0;
            }

            maxLoop -= 1;
        }

        return uidRtn;
    }

    private void RemoveUid(int teamId, int id)
    {
        ids[teamId].Remove(id);
    }
}