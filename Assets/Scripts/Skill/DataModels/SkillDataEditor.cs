using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Skill Set", menuName = "CharacterConfigs/New Skill Data")]
public class SkillDataEditor : SerializedScriptableObject
{
    public UpgradeSkillData UpgradeSkillData;
}