using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Skill Set", menuName = "CharacterConfigs/SkillSet")]
public class CharacterSkillSet : SerializedScriptableObject
{
    public List<SkillDataModels> SkillDataModelses;
}