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
        [SerializeField] private Transform effectTransformParent;
        
        private EffectViewsManager _effectViewsManager;

        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);

            _entity.AddEffectDataChangedListener(this);

            _effectViewsManager = new EffectViewsManager();
            _effectViewsManager.Init(_entity, effectTransformParent);
        }

        public override void OnEntityDestroyed()
        {
            _entity.RemoveEffectDataChangedListener(this);
            base.OnEntityDestroyed();
        }

        public override void OnUpdate(float dt)
        {
            base.OnUpdate(dt);

            _effectViewsManager.CheckEffectsView();
            _effectViewsManager.UpdateViews(dt);
        }

        public void OnEffectDataChanged(GameEntity entity)
        {
            Debug.Log("OnEffectDataChanged>>>>> ");
        }
    }
}