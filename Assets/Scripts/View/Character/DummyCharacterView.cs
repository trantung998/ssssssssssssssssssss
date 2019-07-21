using Character;
using Entitas;
using TMPro;
using UnityEngine;

namespace View.Character
{
    public class DummyCharacterView : UnityViewController
    {
        [SerializeField] private TextMeshPro healthValueText;

        private CharacterStatsComponent _statsComponent;

        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);
            _statsComponent = _entity.characterCharacterStats;
        }

        public override void OnUpdate(float dt)
        {
            base.OnUpdate(dt);
        }
    }
}