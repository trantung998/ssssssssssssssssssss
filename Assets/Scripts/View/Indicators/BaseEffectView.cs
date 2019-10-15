using TMPro;
using UnityEngine;

namespace View.Indicators
{
    public class BaseEffectView
    {
        [SerializeField] private TextMeshPro _effectNameText;
        [SerializeField] private TextMeshPro _effectDurationText;

        private GameEntity _entity;

        public virtual void InitData(GameEntity gameEntity)
        {
            _entity = gameEntity;
        }

        protected virtual string GetEffectName()
        {
            return "BaseEffectName";
        }

        protected virtual float GetCurrentEffectTime()
        {
            return 0f;
        }

        public virtual void Show()
        {
            CreateEffectVisual();
        }

        public virtual void Hide()
        {
        }

        public virtual void OnUpdate(float dt)
        {
        }

        protected virtual void CreateEffectVisual()
        {
            var prefab = GetEffectVisualPrefab();
            prefab.Spawn();
        }

        protected virtual GameObject GetEffectVisualPrefab()
        {
            return null;
        }
    }
}