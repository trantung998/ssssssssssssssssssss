using Character;
using Entitas;
using TMPro;
using UnityEngine;
using View.Indicators;

namespace View.Character
{
    public class DummyCharacterView : UnityViewController, IEffectDataChangedListener
    {
        [SerializeField] private TextMeshPro healthValueText;

        private CharacterStatsComponent _statsComponent;
        private EffectViewsManager _effectViewsManager;
        
        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);
            _statsComponent = _entity.characterCharacterStats;
            _entity.AddEffectDataChangedListener(this);
        }

        public override void OnEntityDestroyed()
        {
            _entity.RemoveEffectDataChangedListener(this);
            base.OnEntityDestroyed();
        }

        public override void OnUpdate(float dt)
        {
            base.OnUpdate(dt);
            healthValueText.text = "Hp: " + _statsComponent.value.health;
        }

        public void OnEffectDataChanged(GameEntity entity)
        {
            Debug.Log("OnEffectDataChanged>>>>> ");
        }
    }
}