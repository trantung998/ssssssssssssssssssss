using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[Serializable]
public class SkillDataModels
{
    public int skillId;

    public List<SkillElementData> ElementDatas;
}

[Serializable]
public class UpgradeSkillData
{
    public int skillIndex;
    public List<UpgradeElementData> ElementIds;
}

[Serializable]
public class UpgradeElementData
{
    [LabelText("Id")] public SkillElementId ElementId;

    public SkillElementValueType ValueType;

//    [TableList(ShowIndexLabels = true)] [TableColumnWidth(50)]
    public List<float> ElementValues;

//    [Button]
    private void AddLevel()
    {
        if (ElementValues != null) ElementValues.Add(0f);
    }
}