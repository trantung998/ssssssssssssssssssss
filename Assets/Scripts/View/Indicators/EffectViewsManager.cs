using System;
using System.Collections.Generic;
using System.Diagnostics;
using Combat;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace View.Indicators
{
    public class EffectViewsManager
    {
        private Dictionary<EffectId, BaseEffectView> _effectViews;

        private GameEntity _selfEntity;
        private Transform _parentTransform;

        public EffectViewsManager()
        {
            _effectViews = new Dictionary<EffectId, BaseEffectView>();
        }

        public void Init(GameEntity entity, Transform parent)
        {
            _selfEntity = entity;
            _parentTransform = parent;
        }

        public void CheckEffectsView()
        {
            if (!_selfEntity.hasActiveEffect) return;
            
            var activeEffectData = _selfEntity.activeEffect.value;
            foreach (var baseEffectData in activeEffectData)
            {
                var isEffectActive = baseEffectData.Value.RemainTime > 0;
                BaseEffectView effectView = null;
                //nếu effect đang được active
                if (isEffectActive)
                {
                    //nếu chưa có view thì tạo mới
                    if (!_effectViews.TryGetValue(baseEffectData.Key, out effectView))
                    {
                        //tạo view mới
                        effectView = CreateEffectView(baseEffectData.Value);
                        _effectViews.Add(baseEffectData.Key, effectView);
                    }

                    //show effectView
                    effectView.Show();
                }
                // nếu không active 
                else
                {
                    //remove view: baseEffectData.Key
                    if (_effectViews.TryGetValue(baseEffectData.Key, out effectView))
                    {
                        Debug.Log("CheckEffectsView remove eff view");
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
            var effectPrefabPath = string.Format("Prefabs/CombatEffectVisuals/{0}EffectVisual", effectId);
            var effectObject = ObjectPool.Spawn(effectPrefabPath, _parentTransform);

            BaseEffectView effectView = effectObject.GetComponent<BaseEffectView>();
            effectView.InitData(_selfEntity, effectId);

            return effectView;
        }
    }
}