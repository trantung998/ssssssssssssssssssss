using Character;
using Entitas;
using TMPro;
using UnityEngine;

namespace View.Character
{
    public class DummyCharacterView : UnityViewController, ICharacterPositionListener
    {
        [SerializeField] private TextMeshPro healthValueText;

        private CharacterStatsComponent _statsComponent;

        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);
            _statsComponent = _entity.characterCharacterStats;

            _entity.AddCharacterPositionListener(this);
        }

        public override void OnEntityDestroyed()
        {
            _entity.characterPositionListener.value.Remove(this);
            base.OnEntityDestroyed();
        }

        public override void OnUpdate(float dt)
        {
            base.OnUpdate(dt);
            healthValueText.text = "Hp: " + _statsComponent.value.health;
        }

        public void OnCharacterPosition(GameEntity entity, Vector3 value)
        {
            Position = value;
        }
    }
}