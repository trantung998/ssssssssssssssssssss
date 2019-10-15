using System;
using System.Collections.Generic;
using System.Diagnostics;
using Combat;
using UnityEngine;

namespace View.Indicators
{
    public class EffectViewsManager
    {
        private Dictionary<EffectId, BaseEffectView> _effectViews;

        private GameEntity _selfEntity;
        private Transform _parentTransform;

        public void Init(GameEntity entity, Transform parent)
        {
            _selfEntity = entity;
            _parentTransform = parent;
        }

        private void CheckEffectsView()
        {
            var activeEffectData = _selfEntity.activeEffect.value;
            foreach (var baseEffectData in activeEffectData)
            {
                var isEffectActive = baseEffectData.Value.RemainTime > 0;

                if (!_effectViews.ContainsKey(baseEffectData.Key))
                {
                    if (isEffectActive)
                    {
                        //tạo view mới
                    }
                }
                else
                {
                    if (!isEffectActive)
                    {
                        //remove view: baseEffectData.Key
                        var effectView = _effectViews[baseEffectData.Key];
                        effectView.Hide();
                        _effectViews.Remove(baseEffectData.Key);
                    }
                }
            }
        }

        public void UpdateViews(float dt)
        {
            foreach (var keyValuePair in _effectViews)
            {
                keyValuePair.Value.OnUpdate(dt);
            }
        }

        private BaseEffectView CreateEffectView(BaseEffectData baseEffectData)
        {
            var effectId = baseEffectData.EffectId;
            BaseEffectView effectView = null;
            switch (effectId)
            {
                case EffectId.Stun:
                    break;
                case EffectId.Slow:
                    break;
            }

            return effectView;
        }
    }
}