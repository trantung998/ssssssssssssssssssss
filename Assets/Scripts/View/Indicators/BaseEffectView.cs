using Combat;
using TMPro;
using UnityEngine;

public class BaseEffectView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _effectNameText;
    [SerializeField] private TextMeshPro _effectDurationText;

    protected GameEntity _entity;
    protected EffectId _effectId;

    public virtual void InitData(GameEntity gameEntity, EffectId effectId)
    {
        _entity = gameEntity;
        _effectId = effectId;
    }

    protected virtual string GetEffectName()
    {
        return _effectId.ToString();
    }

    protected virtual float GetCurrentEffectTime()
    {
        var activeEffectData = _entity.activeEffect.GetEffectData(_effectId);
        if (activeEffectData != null) return activeEffectData.RemainTime;
        return 0f;
    }

    public virtual void Show()
    {
        _effectNameText.text = GetEffectName();
    }

    public virtual void Hide()
    {
        gameObject.Recycle();
    }

    public virtual void OnUpdate(float dt)
    {
        _effectDurationText.text = string.Format("Duration: {0}", GetCurrentEffectTime());
    }
}