using System.Collections.Generic;
using Combat;

namespace View.Indicators
{
    public class EffectViewsManager
    {
        private Dictionary<EffectId, BaseEffectView> _effectViews;
        private GameEntity _selfEntity;
        public void Init(GameEntity entity)
        {
        }

        private void CheckEffectsView()
        {
            var effectsData = _selfEntity.effectData.value;
        }

    }
}