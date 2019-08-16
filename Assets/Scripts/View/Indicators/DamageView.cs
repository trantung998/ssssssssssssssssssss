using DG.Tweening;
using Entitas;
using Indicator;
using TMPro;
using UnityEngine;

namespace View.Indicators
{
    public class DamageView : UnityViewController
    {
        [SerializeField] private TextMeshPro valueText;

        private DamageIndicatorData _damageIndicatorData;

        public override void InitializeView(Contexts contexts, IEntity entity)
        {
            base.InitializeView(contexts, entity);
            _damageIndicatorData = this._entity.indicatorIndicator.value as DamageIndicatorData;
            if (_damageIndicatorData != null)
            {
                valueText.text = "" + _damageIndicatorData.value;
                if (_damageIndicatorData.isCriticalHit)
                {
                    valueText.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                }
                else
                {
                    valueText.transform.localScale = Vector3.one;
                }
            }

            valueText.transform.DOMoveY(transform.position.y + 0.5f, 0.3f)
                .OnComplete(() => { this._entity.AddDestroyed(0f); });
        }

        public override void OnEntityDestroyed()
        {
            gameObject.Recycle();
            base.OnEntityDestroyed();
        }
    }
}